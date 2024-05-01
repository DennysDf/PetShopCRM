using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Models.Payment;
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
    IPaymentService paymentService,
    IPaymentHistoryService paymentHistoryService) : Controller
{

    public async Task<IActionResult> Index()
    {
        await CardGuardians();
        await CardVendas();
        await CardFaturamento();
        await CardPet();
        await ChartPieSpecie();
        await ChartFaturamentoAnual();
        await ChartFaturamentoAnualIndividual();
        await ChartArea();

        return View();
    }

    public async Task CardGuardians()
    {
        var guardiansReport = new GuardiansReport();

        var guardians = await guardianService.GetAllAsync();

        ViewData["PercentGuardians"] = guardiansReport.GetPercent(guardians);

        ViewData["QtdGuardians"] = guardiansReport.GetQtdGuardians(guardians);

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

        var paymentsDTO = await paymentHistoryService.GetAllCompleteAsync();
        var payments = paymentsDTO.Data;

        ViewData["QtdFaturamento"] = revenueReport.GetQtdPayments(payments);
        ViewData["PercentFaturamento"] = revenueReport.GetPercent(payments);
        ViewData["TypeTextFaturamento"] = revenueReport.GetTypeText(payments);
        ViewData["ArrowFaturamento"] = revenueReport.GetArrow(payments);
    }

    public async Task CardPet()
    {
        var petsReport = new PetsReport();

        var petsDTO = await petService.GetAllCompleteAsync();
        var pets = petsDTO.Data;

        ViewData["QtdPets"] = petsReport.GetQtdPets(pets);
        ViewData["PercentPets"] = petsReport.GetPercent(pets);
        ViewData["TypeTextPets"] = petsReport.GetTypeText(pets);
        ViewData["ArrowPets"] = petsReport.GetArrow(pets);

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

    public async Task ChartFaturamentoAnualIndividual()
    {
        var paymentsDTO = await paymentHistoryService.GetAllCompleteAsync();
        var payments = paymentsDTO.Data;

        var faturamentoAnual = payments.Select(c => new
        {
            c.Value,
            c.Payment.HealthPlan.Name,
            mes = c.CreatedDate.Month
        })
        .GroupBy(c => new { c.Name })
        .Select(c => new
        {
            Name = c.Key.Name,
            Data = new Decimal[]
            {
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 1).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 2).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 3).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 4).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 5).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 6).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 7).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 8).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 9).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 10).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 11).Sum(s => s.Value))),
                Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.mes == 12).Sum(s => s.Value)))
            }
        }).ToArray();



        ViewData["ObjFaturamentoAnual"] = JsonConvert.SerializeObject(faturamentoAnual);
    }

    public async Task ChartFaturamentoAnual()
    {

        var paymentsDTO = await paymentHistoryService.GetAllCompleteAsync();
        var payments = paymentsDTO.Data;

        var faturamentoAnualIndividual = payments.Select(c => new
        {
            c.Value,
            Mes = c.CreatedDate.Month
        })
        .GroupBy(c => new { c.Mes })
        .Select(c => new
        {
            Mes = c.Key.Mes,
            Data = new Decimal[]
        {
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 1).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 2).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 3).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 4).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 5).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 6).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 7).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 8).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 9).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 10).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 11).Sum(s => s.Value))),
            Decimal.Parse(string.Format("{0:0.00}", c.Where(s => s.Mes == 12).Sum(s => s.Value)))
        }
        })
        .Select(c => new
        {
            c.Data,
            c.Mes

        })
        .GroupBy(c => c.Mes)
        .Select(c => new
        {
            c.Key,
            Valor = c.Sum(x => x.Data.Sum())
        })
        .ToArray();


        ViewData["ObjFaturamentoAnualIndividual"] = JsonConvert.SerializeObject(faturamentoAnualIndividual);

    }

    public async Task ChartArea()
    {
        var paymentsDTO = await paymentService.GetAllCompleteAsync();
        var payments = paymentsDTO.Data;

        var faturamentoAnual = payments.Select(c => new
        {
            c.HealthPlan.Value,
            c.HealthPlan.Name,
            mes = c.CreatedDate.Month
        })
        .GroupBy(c => new { c.Name })
        .Select(c => new
        {
            Name = c.Key.Name,
            Data = new int[]
            {
                        c.Where(s => s.mes == 1).Count(),
                        c.Where(s => s.mes == 2).Count(),
                        c.Where(s => s.mes == 3).Count(),
                        c.Where(s => s.mes == 4).Count(),
                        c.Where(s => s.mes == 5).Count(),
                        c.Where(s => s.mes == 6).Count(),
                        c.Where(s => s.mes == 7).Count(),
                        c.Where(s => s.mes == 8).Count(),
                        c.Where(s => s.mes == 9).Count(),
                        c.Where(s => s.mes == 10).Count(),
                        c.Where(s => s.mes == 11).Count(),
                        c.Where(s => s.mes == 12).Count()
            }
        }).ToArray();

        ViewData["ObjFaturamentoArea"] = JsonConvert.SerializeObject(faturamentoAnual);
    }

    [Authorize(policy: nameof(UserType.Admin))]
    public IActionResult Privacy()
    {
        return View();
    }
}
