using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class SpecieController(
    ILogger<SpecieController> logger,
    IUserService userService) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
