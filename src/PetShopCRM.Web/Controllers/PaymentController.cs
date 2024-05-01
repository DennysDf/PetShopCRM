using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PetShopCRM.Application.Services.Interfaces;
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
        IPaymentHistoryService paymentHistoryService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var paymentsDTO = await paymentService.GetAllCompleteAsync();        

        return View(PaymentVM.ToList(paymentsDTO.Data).OrderByDescending(x => x.Id).ToList());
    }

    public async Task<IActionResult> Ajax()
    {
        var pets = await petService.GetAllAsync();
        var healthPlans = await healthPlanService.GetAllAsync();

        var paymentVM = new PaymentVM
        {
            PetList = new SelectList(pets.Select(c => new { c.Id, Name = $"{c.Name} - {c.Guardian.Name}" }).ToList(), nameof(Pet.Id), nameof(Pet.Name)),
            HealthPlanList = new SelectList(healthPlans.Select(c => new { c.Id, Name = $"{c.Name} - R$ {c.Value}" }).ToList(), nameof(HealthPlan.Id), nameof(HealthPlan.Name)),
            Card = new PaymentCardVM
            {
                BrandList = new SelectList(EnumUtil.ToList<CardBrand>(), "Key", "Value")
            },
            BillingAddress = new PaymentBillingAddressVM
            {
                HasBillingAddress = false
            }
        };

        return View(paymentVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(PaymentVM model)
    {
        var result = await paymentService.GenerateAsync(model.PetId, model.HealthPlanId, model.Card.ToDTO(), model.BillingAddress.ToDTO());

        var paymentSuccess = result.Data != null && result.Data.IsSuccess;

        if (!result.Success || !paymentSuccess)
            notificationService.Error(result.Message);
        else
            notificationService.Success(Resources.Text.PaymentAddSuccess);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await paymentService.CancelAsync(id);

        if(success)
            notificationService.Success(Resources.Text.PaymentDeleteSuccess);
        else
            notificationService.Error(Resources.Text.NotificationError);

        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> Webhook([FromBody]WebhookDTO dto)
    {
        try
        {
            var isValid = paymentHistoryService.ValidateEvent(dto.Type);

            if (isValid)
            {
                var result = await paymentHistoryService.SaveAsync(dto.Type, dto.Data);

                if (result.Success && result.Data != null && result.Data.IsSuccess)
                    await paymentService.UpdateLastPaymentDateAndInstallmentAsync(result.Data.PaymentId, result.Data.CreatedDate);
            }

        }
        catch (Exception) { }

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Monitoring(int? paymentId = null)
    {
        var histories = await paymentHistoryService.GetAllAsync(paymentId);

        return View(PaymentHistoryVM.ToList(histories));
    }
}
