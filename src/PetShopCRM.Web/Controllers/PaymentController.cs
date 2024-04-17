﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Models.Clinic;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Models.Payment;
using PetShopCRM.Web.Models.Pet;
using PetShopCRM.Web.Services.Interfaces;
using System.Runtime.InteropServices;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class PaymentController(
        INotificationService notificationService,
        IPaymentService paymentService,
        IPetService petService,
        IHealthPlanService healthPlanService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var payments = await paymentService.GetAllAsync();

        return View(PaymentVM.ToList(payments));
    }

    public async Task<IActionResult> Ajax()
    {
        var pets = await petService.GetAllAsync();
        var healthPlans = await healthPlanService.GetAllAsync();

        var paymentVM = new PaymentVM
        {
            PetList = new SelectList(pets.Select(c => new { c.Id, c.Name }).ToList(), nameof(Pet.Id), nameof(Pet.Name)),
            HealthPlanList = new SelectList(healthPlans.Select(c => new { c.Id, c.Name }).ToList(), nameof(HealthPlan.Id), nameof(HealthPlan.Name)),
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

}