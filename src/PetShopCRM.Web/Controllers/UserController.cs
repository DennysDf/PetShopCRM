using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models;
using PetShopCRM.Web.Util;

namespace PetShopCRM.Web.Controllers
{
    public class UserController(
        IHttpContextAccessor httpContextAccessor,
        IUserService userService) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            await userService.AddAsync(new Domain.Models.User { Active = true, Name = "Kevyn", Login = "kevyn", Password = "123" });

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
                        await LoginUtil.LoginAsync(httpContextAccessor, response.Data);

                        return RedirectToAction("Index", "Home");
                    }
                }

                ModelState.TryAddModelError(nameof(userLogin.Login), Resources.ValidationMessages.UserNotFound);

                return View(userLogin);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await LoginUtil.LogoutAsync(httpContextAccessor);
                
                return RedirectToAction(nameof(Login));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
