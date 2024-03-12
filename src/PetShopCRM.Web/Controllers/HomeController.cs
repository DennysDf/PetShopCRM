using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Web.Models;
using PetShopCRM.Web.SignalHubs;
using System.Diagnostics;
using System.Security.Claims;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class HomeController(
    ILogger<HomeController> logger,
    IHubContext<NotificationHub> hubContext,
    IUserService userService) : Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }

    [Authorize(policy: nameof(UserType.Admin))]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public async Task Ajax()
    {
        await hubContext.Clients.All.SendAsync("ReceiveNotification", HttpContext.User.FindFirstValue("Id"), nameof(NotificationType.Information), "Sucesso!");
    }
}
