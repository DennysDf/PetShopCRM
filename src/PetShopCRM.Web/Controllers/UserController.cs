﻿using Azure;
using EmailHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Models.User;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers
{
    [Authorize]
    public class UserController(
        ILoginService loginService,
        INotificationService notificationService,
        IUserService userService, ILoggedUserService loggedUserService,
        IUpload upload, IEmailService emailService) : Controller
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
                var response = await userService.ValidateAsync(userLogin.ToDTO());
                var user = response.Data;
                if (response.Success)
                {
                    await loginService.LoginAsync(user);
                    var locale = string.Empty;

                    switch (user.Type)
                    {
                        case UserType.Admin:
                            locale = "Index";
                            break;
                        case UserType.General:
                            locale = "Index";
                            break;
                        case UserType.Guardian:
                            locale = "Guardian";
                            break;                            
                    }

                    notificationService.Success(Resources.Text.UserLogged);

                    return RedirectToAction(locale, "Home");
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
            ViewData["Route"] = loggedUserService.Role == UserType.Guardian.ToString() ? "Guardian" : "Index";
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
                {
                    await loginService.LoginAsync(response.Data);
                    notificationService.Success(response.Message);
                }                
                else
                    notificationService.Error();
            }

            

            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> AddUser()
        {
            var users = await userService.GetAllAsync();

            

            return View(AddUserVM.ToList(users));
        }

        public async Task<IActionResult> AjaxUser(int id)
        {
            var userDTO = await userService.GetUserByIdAsync(id);
            var userVM = new AddUserVM();

            if (userDTO.Success)
                userVM = userVM.ToVM(userDTO.Data);

        var typeUsers = new SelectList(EnumUtil.ToList<UserType>(), "Key", "Value");
        userVM.TyUserList = typeUsers;

            return View(userVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserVM model)
        {
            var message = model.Id != 0 ? Resources.Text.UserUpdateSucess : Resources.Text.UserAddSucess;
            
            await userService.AddOrUpdateAsync(model.ToModel());

            notificationService.Success(message);

            return RedirectToAction("AddUser");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var guardian = await userService.DeleteAsync(id);
            notificationService.Success(Resources.Text.UserDeleteSucess);

            return RedirectToAction("AddUser");
        }

        [AllowAnonymous]
        public IActionResult RestorePassword()
        {

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<string> RestorePassword(string login)
        {   
            var userDTO = userService.GetUserByCPForEmail(login.ExtractCpfNumbers());
            var message = "Usuário não contrato, digite o CPF ou e-mail usando no momento do cadastro.";

            if (userDTO.Success)
            {
                var model = userDTO.Data;
                var email = model.Email;
                message = $"E-mail de recuperação enviado para {email.MaskEmail()}.";                
                await emailService.SendAsync(model.Email, "Recuperação de senha", $"<p>Olá {model.Name},<p>Para redefinir sua senha, clique no link abaixo:<p><a href=\"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/User/RestorePasswordExternal?id={model.Id.EncryptNumberAsBase64()}\">Link de Recuperação de Senha</a></p><br><p>Atenciosamente, VetCard.", true);
            }

            return message;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult RestorePasswordExternal(string id)
        {
            return View(new UserLoginVM() { Id = id});
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> RestorePasswordExternal(UserLoginVM model)
        {
            var id = model.Id.DecryptNumberFromBase64();

            var userDTO = await userService.GetUserByIdAsync(id);

            if (userDTO.Success)
            {
                var user = userDTO.Data;
                user.Password = model.PasswordNew;
                await userService.AddOrUpdateAsync(user);
                notificationService.Success(Resources.Text.UserPassawordUpdate);
            }
            else
                notificationService.Error();

            return RedirectToAction("Login");
        }
        public async Task<bool> ValidatePassword(string password)
        {
            var userDTO = await userService.GetUserByIdAsync(loggedUserService.Id);         

            return userDTO.Data.Password == password;
        }
    }
}
