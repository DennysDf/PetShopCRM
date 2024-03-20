using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class PetController(
    ILogger<PetController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
