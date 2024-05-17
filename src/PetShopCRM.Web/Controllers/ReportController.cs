using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

public class ReportController(IPetService petService) : Controller
{
    public IActionResult Index()
    {
        var teste = petService.GetPetsForUpdateImg();

        return View(teste);
    }
}
