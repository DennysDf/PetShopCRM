using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Pet;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class PetController(
    ILogger<PetController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        var pets = new List<PetVM>();

        return View(pets);
    }

    public IActionResult Ajax(int id)
    {

        return View();
    }

}
