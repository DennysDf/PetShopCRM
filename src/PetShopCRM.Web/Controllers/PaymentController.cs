using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Models.Payment;
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
        ILoggedUserService loggedUserService,
        IWebContext webContext,
        IGuardianService guardianService) : Controller
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
    
    public async Task<IActionResult> Form()
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
    public async Task<IActionResult> Form(PaymentVM model)
    {
        var result = await paymentService.AddOrUpdateAsync(model.PetId, model.HealthPlanId, null, model.Card.ToDTO(), model.BillingAddress.ToDTO(), model.Customer.ToDTO());

        if (result.Success && result.Data != null && result.Data.ExternalId == null)
            notificationService.Success(Resources.Text.PaymentAndEmailAddSuccess);

        if(result.Success && result.Data != null && result.Data.IsSuccess)
            notificationService.Success(Resources.Text.PaymentAddSuccess);

        if (!result.Success || (result.Data != null && !result.Data.IsSuccess && result.Data.ExternalId != null))
            notificationService.Error(result.Message);

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

    [AllowAnonymous]
    public async Task<IActionResult> Checkout(string refId)
    {
        var paymentId = 6;//refId.DecryptNumberFromBase64();

        var payment = paymentService.GetById(paymentId);
        var pets = await petService.GetAllAsync();
        var healthPlans = await healthPlanService.GetAllAsync();

        ViewData["HealthPlan"] = (await healthPlanService.GetByIdAsync(payment.HealthPlanId)).Data;
        ViewData["Pet"] = (await petService.GetByIdAsync(payment.PetId)).Data;
        ViewData["Guardian"] = (await guardianService.GetByIdAsync(payment.GuardianId)).Data;

        var paymentVM = new PaymentVM
        {
            Id = paymentId,
            PetId = payment.PetId,
            PetList = new SelectList(pets.Select(c => new { c.Id, Name = $"{c.Name} - {c.Identifier} - {c.Guardian.Name}" }).ToList(), nameof(Pet.Id), nameof(Pet.Name)),
            HealthPlanId = payment.HealthPlanId,
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

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Checkout(PaymentVM model)
    {
        var result = await paymentService.AddOrUpdateAsync(model.PetId, model.HealthPlanId, model.Id, model.Card.ToDTO(), model.BillingAddress.ToDTO(), model.Customer.ToDTO());

        return Redirect(webContext.GeSystemUrl());
    }
}
