using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models;
using PetShopCRM.Web.Services.Interfaces;
using PetShopCRM.Web.Util;

namespace PetShopCRM.Web.Controllers
{
    public class UserController(
        ILoginService loginService,
        INotificationService notificationService,
        IUserService userService) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginVM userLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await userService.ValidateUser(userLogin.ToDTO());

                    if (response.Success)
                    {
                        await loginService.LoginAsync(response.Data);

                        notificationService.Success(Resources.Text.UserLogged);

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.TryAddModelError(nameof(userLogin.Login), Resources.ValidationMessages.UserNotFound);

                return View(userLogin);
            }
            catch (Exception ex)
            {
                ModelState.TryAddModelError(nameof(userLogin.Login), ex.Message);

                return View(userLogin);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await loginService.LogoutAsync();
                
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
