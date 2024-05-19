using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

public class ReportController(IPetService petService) : Controller
{
    public IActionResult UpdateImg()
    {
        var pets = petService.GetPetsForUpdateImg().OrderByDescending(c => c.Days).ToList();

        return View(pets);
    }
}
