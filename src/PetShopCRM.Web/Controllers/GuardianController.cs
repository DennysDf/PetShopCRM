using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Services;
using PetShopCRM.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class GuardianController(
        ILoginService loginService,
        INotificationService notificationService,
        IGuardianService guardianService, ILoggedUserService loggedUserService, IAddressService addressService,
        IUpload upload, IPaymentHistoryService paymentHistoryService, IPaymentService paymentService, IPetService petService, IUserService userService, IEmailService emailService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var guardians = await guardianService.GetAllAsync();

        var guardianVMList = new GuardianVM().ToList(guardians);

        return View(guardianVMList);
    }

    public async Task<IActionResult> Ajax(int id)
    {
        var guardianDTO = await guardianService.GetByIdAsync(id);
        var guardianVM = new GuardianVM();
        if (id != 0)
        {
            if (guardianDTO.Success)
            {
                guardianVM = guardianVM.ToVM(guardianDTO.Data);
            }
            else 
            {
                notificationService.Send(Domain.Enums.NotificationType.Error, guardianDTO.Message, loggedUserService.Id);
            }
        }
        return View(guardianVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(GuardianVM model)
    {
        var message = model.Id != 0 ? Resources.Text.GuardianUpdateSucess : Resources.Text.GuardianAddSucess;
        model.Country = "BR";

        var guardian = model.ToModel();

        await guardianService.AddOrUpdateAsync(guardian);
        
        if (model.Id == 0) 
        {
            var user = model.ToModelUser();
            user.GuardianId = guardian.Id;

            await userService.AddOrUpdateAsync(user);
            await emailService.SendAsync(model.Email,"Usuário VetCard", $"<p>Olá <strong>{model.Name}</strong>,<p>Seu login e senha para acessar o sistema VetCard foram criados com sucesso.<p><strong>Login:</strong> {model.CPF.Replace(".","").Replace("-","")}<br><strong>Senha:</strong> vetcard123<p>Por favor, acesse <a href=http://plano.vetcard.com.br>nosso sistema</a> para fazer o login e começar a usar nossos serviços.<p>Se precisar de ajuda ou tiver qualquer dúvida, estamos à disposição.<p>Atenciosamente,<p>Equipe VetCard",true);
        }

        notificationService.Success(message);
        
        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var guardian = await guardianService.DeleteAsync(id);
        notificationService.Success(Resources.Text.GuardianDeleteSucess);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<string> GetAddressByCEP(string CEP)
    {
        var address = await addressService.GetByCEP(CEP);
        return JsonSerializer.Serialize(address.Data);
    }
}
