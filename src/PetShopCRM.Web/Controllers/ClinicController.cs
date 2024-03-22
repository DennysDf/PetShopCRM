
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Clinic;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class ClinicController(
    ILogger<ClinicController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        var clinic = new List<ClinicVM>();

        return View(clinic);
    }

    public IActionResult Ajax()
    {
        return View();
    }
}
