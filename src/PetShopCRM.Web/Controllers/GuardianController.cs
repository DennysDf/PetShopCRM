using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Guardian;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class GuardianController(
    ILogger<GuardianController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        var guardian = new List<GuardianVM>();

        return View(guardian);
    }

    public IActionResult Ajax(int id)
    {
        return View();
    }
}
