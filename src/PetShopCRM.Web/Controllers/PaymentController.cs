using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Models.Payment;
using PetShopCRM.Web.Services;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class PaymentController(
        INotificationService notificationService,
        IPaymentService paymentService,
        IPetService petService,
        IHealthPlanService healthPlanService,
        IPaymentHistoryService paymentHistoryService,
        IConfigurationService configurationService,
        IEmailService emailService,
        ILoggedUserService loggedUserService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var paymentsDTO = await paymentService.GetAllCompleteAsync();        

        var paymentsVM = PaymentVM.ToList(paymentsDTO.Data).OrderByDescending(x => x.Id).ToList();

        var configDashboardUrl = configurationService.GetByKey(Domain.Enums.ConfigurationKey.PagarMeDashboardUrl);

        if (configDashboardUrl != null && !string.IsNullOrEmpty(configDashboardUrl.Value))
        {
            var dashboardUri = new Uri(configDashboardUrl.Value);
            var url = dashboardUri.GetLeftPart(UriPartial.Path);

            for (int i = 0; i < paymentsVM.Count; i++)
            {
                paymentsVM[i].ExternalIdUrl = $"{url}subscriptions/{paymentsVM[i].ExternalId}/info";
            }
        }

        return View(paymentsVM);
    }

    public async Task<IActionResult> Ajax()
    {
        var pets = await petService.GetAllAsync();
        var healthPlans = await healthPlanService.GetAllAsync();

        var paymentVM = new PaymentVM
        {
            PetList = new SelectList(pets.Select(c => new { c.Id, Name = $"{c.Name} - {c.Identifier} - {c.Guardian.Name}" }).ToList(), nameof(Pet.Id), nameof(Pet.Name)),
            HealthPlanList = new SelectList(healthPlans.Select(c => new { c.Id, Name = $"{c.Name} - R$ {c.Value}" }).ToList(), nameof(HealthPlan.Id), nameof(HealthPlan.Name)),
            Card = new PaymentCardVM
            {
                BrandList = new SelectList(EnumUtil.ToList<CardBrand>(), "Key", "Value")
            },
            BillingAddress = new PaymentBillingAddressVM
            {
                HasBillingAddress = false
            },
            Customer = new PaymentCustomerVM
            {
                HasCustomer = false
            }
        };

        return View(paymentVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(PaymentVM model)
    {
        var result = await paymentService.GenerateAsync(model.PetId, model.HealthPlanId, model.Card.ToDTO(), model.BillingAddress.ToDTO(), model.Customer.ToDTO());

        var paymentSuccess = result.Data != null && result.Data.IsSuccess;

        if (!result.Success || !paymentSuccess)
            notificationService.Error(result.Message);
        else 
        { 
            notificationService.Success(Resources.Text.PaymentAddSuccess);
            var pay = await paymentService.GetAllCompleteAsync(result.Data.Id);
            var model2 = pay.Data.First();
            await emailService.SendAsync(model2.Guardian.Email,"Bem vindo ao Plano de Saúde Pet VetCard.", $"<p>Prezado(a) {model2.Guardian.Name},<p>Esperamos que você e seu amado pet estejam bem.<p>É com grande satisfação que informamos que a compra do plano de saúde para o seu pet foi realizada com sucesso! Agradecemos pela confiança em nossos serviços e estamos felizes em tê-lo como nosso cliente.<p><strong>Detalhes do Plano Adquirido:</strong><ul><li><strong>Plano:</strong> {model2.HealthPlan.Name}</ul><p>Para visualizar todos os benefícios que o seu plano oferece, por favor, clique <a href=http://vetcard.com.br/ >aqui</a>.<p>Caso tenha alguma dúvida ou necessite de assistência, não hesite em entrar em contato conosco. Estamos à disposição para ajudar no que for necessário.<p>Mais uma vez, agradecemos pela sua compra e esperamos que você e seu pet tenham uma excelente experiência com o VetCard.<p>Atenciosamente,<p>Equipe VetCard", true);
            
        }

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id, string route = null)
    {
        var success = await paymentService.CancelAsync(id);

        if (success)
            notificationService.Success(Resources.Text.PaymentDeleteSuccess);
        else
            notificationService.Error(Resources.Text.NotificationError);

        if (route != null)
        {
            var petId = paymentService.GetById(id).PetId;
            return RedirectToAction("DetailsHealthPlan", "Guardian", new { Id = petId });
        }

        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Webhook([FromBody] WebhookDTO dto)
    {
        try
        {
            var isValid = paymentHistoryService.ValidateEvent(dto.Type);

            if (isValid)
            {
                var result = await paymentHistoryService.SaveAsync(dto.Type, dto.Data);

                if (result.Success && result.Data != null && result.Data.IsSuccess)
                {
                    await paymentService.UpdateLastPaymentDateAndInstallmentAsync(result.Data.PaymentId, result.Data.CreatedDate);
                }
            }

        }
        catch (Exception) { }

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Monitoring(int? paymentId = null)
    {
        ViewData["Route"] = loggedUserService.Role == UserType.Guardian.ToString() ? "Guardian" : "Index";

        var histories = await paymentHistoryService.GetAllAsync(paymentId);

        var historiesVM = PaymentHistoryVM.ToList(histories);

        var configDashboardUrl = configurationService.GetByKey(Domain.Enums.ConfigurationKey.PagarMeDashboardUrl);

        if (configDashboardUrl != null && !string.IsNullOrEmpty(configDashboardUrl.Value))
        {
            var dashboardUri = new Uri(configDashboardUrl.Value);
            var url = dashboardUri.GetLeftPart(UriPartial.Path);

            for (int i = 0; i < historiesVM.Count; i++)
            {
                historiesVM[i].ExternalIdUrl = $"{url}subscriptions/{historiesVM[i].ExternalId}/info";
            }
        }

        return View(historiesVM);
    }
}
