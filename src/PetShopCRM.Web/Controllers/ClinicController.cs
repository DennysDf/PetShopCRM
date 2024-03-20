
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

public class ClinicController(
    ILogger<ClinicController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
