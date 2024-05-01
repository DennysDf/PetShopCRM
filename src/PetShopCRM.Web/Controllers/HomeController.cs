using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Reports;
using PetShopCRM.Web.SignalHubs;
using Polly.Bulkhead;
using System.Diagnostics;
using System.Security.Claims;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class HomeController(
    ILogger<HomeController> logger,
    IUserService userService, 
    ISpecieService specieService, 
    IGuardianService guardianService, 
    IPetService petService,
    IPaymentService paymentService) : Controller
{

    public async Task<IActionResult> Index()
    {
        await CardGuardians();
        await CardVendas();        
        await CardFaturamento();
        await CardGrowth();
        await ChartPieSpecie();

        return View();
    }

    public async Task CardGuardians()
    {
        var guardiansReport = new GuardiansReport();

        var guardians = await guardianService.GetAllAsync();

        ViewData["PercentGuardians"] = guardiansReport.GetPercent(guardians);

        ViewData["QtdGuardians"] =  guardiansReport.GetQtdGuardians(guardians);

        ViewData["TypeTextGuardians"] = guardiansReport.GetTypeText(guardians);

        ViewData["ArrowGuardians"] = guardiansReport.GetArrow(guardians);

    }

    public async Task CardVendas()
    {
        var salesRepot = new SalesReport();

        var payments = await paymentService.GetAllCompleteAsync();

        ViewData["PercentPayments"] = salesRepot.GetPercent(payments.Data);

        ViewData["QtdPayments"] = salesRepot.GetQtdPayments(payments.Data);

        ViewData["TypeTextPayments"] = salesRepot.GetTypeText(payments.Data);

        ViewData["ArrowPayments"] = salesRepot.GetArrow(payments.Data);
    }

    public async Task CardFaturamento()
    {
        var revenueReport = new RevenueReport();

        var paymentsDTO = await paymentService.GetAllCompleteAsync();
        var payments = paymentsDTO.Data;

        ViewData["QtdFaturamento"] = revenueReport.GetQtdPayments(payments);
        ViewData["PercentFaturamento"] = revenueReport.GetPercent(payments);
        ViewData["TypeTextFaturamento"] = revenueReport.GetTypeText(payments);
        ViewData["ArrowFaturamento"] = revenueReport.GetArrow(payments);
    }

    public async Task CardGrowth()
    {
        var growthReport = new GrowthReport();

        var paymentsDTO = await paymentService.GetAllCompleteAsync();
        var payments = paymentsDTO.Data;        
        var guardians = await guardianService.GetAllAsync();


        ViewData["QtdGrowth"] = growthReport.GetPercent(guardians, payments); ;
        ViewData["PercentGrowth"] = growthReport.GetPercentDifference(guardians, payments);
        ViewData["TypeTextGrowth"] = growthReport.GetTypeText(guardians, payments);
        ViewData["ArrowGrowth"] = growthReport.GetArrow(guardians, payments);

    }

    public async Task ChartPieSpecie()
    {
        var petsDTO = await petService.GetAllCompleteAsync();
        var pets = petsDTO.Data;

        ViewData["ObjSpecies"] = JsonConvert.SerializeObject(pets.Select(c => new
        {
            c.Specie.Name,
            Qtd = c.SpecieId
        }).GroupBy(c => new { c.Qtd, c.Name })
        .Select(c => new
        {
            Index = c.Count(x => x.Qtd == c.Key.Qtd),
            c.Key.Name,
        })
        .OrderByDescending(c => c.Index)
        .ToArray());
    }

    [Authorize(policy: nameof(UserType.Admin))]
    public IActionResult Privacy()
    {
        return View();
    }
}
