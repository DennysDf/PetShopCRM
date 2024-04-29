using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        var payments = paymentsDTO.Data;

        return View(PaymentVM.ToList(payments));
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

        if (!result.Success)
            notificationService.Error(result.Message);
            
        notificationService.Success(Resources.Text.PaymentAddSuccess);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await petService.DeleteAsync(id);
        notificationService.Success(Resources.Text.PetDeleteSucess);

        return RedirectToAction("Index");
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> WebhookAsync(WebhookDTO dto)
    {
        var isValid = paymentHistoryService.ValidateEvent(dto.type);

        if(isValid)
            _ = await paymentHistoryService.SaveAsync(dto.id, dto.type, dto.data.amount.ToString().StringLiteralToDecimal());

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Monitoring()
    {
        var histories = await paymentHistoryService.GetAllAsync();

        return View(PaymentHistoryVM.ToList(histories));
    }
}
