using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Specie;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class SpecieController(
    ILogger<SpecieController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        var specie = new List<SpecieVM>();

        return View(specie);
    }

    public IActionResult Ajax(int id)
    {
        return View();
    }
}
