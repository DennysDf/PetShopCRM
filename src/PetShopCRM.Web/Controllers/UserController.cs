using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Models.User;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers
{
    [Authorize]
    public class UserController(
        ILoginService loginService,
        INotificationService notificationService,
        IUserService userService, ILoggedUserService loggedUserService,
        IUpload upload) : Controller
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
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
                    var response = await userService.ValidateAsync(userLogin.ToDTO());

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

        public async Task<IActionResult> Profile()
        {
            var user = await userService.GetUserByIdAsync(loggedUserService.Id);
            var profile =  new ProfileVM();
            profile.ToViewModel(user.Data);

            return View(profile);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(ProfileVM model)
        {
            if (ModelState.IsValid)
            {
                model.Id = loggedUserService.Id;
                model.NamePhoto = upload.GetNameFile(model.Photo ?? null);
                var response = await userService.UpdateAsync(model.ToDTO());

                if (model.Photo != null)              
                    upload.SavePhotoProfile(model.Photo, model.Id);

                if (response.Success)                
                    notificationService.Success(response.Message);                
                else
                    notificationService.Error();
            }

            return RedirectToAction("Index","Home");
        }

        public bool ValidatePassword(int id )
        {
            return true;
        }
    }
}
