using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class GuardianController(
        ILoginService loginService,
        INotificationService notificationService,
        IGuardianService guardianService, ILoggedUserService loggedUserService, IAddressService addressService,
        IUpload upload, IPaymentHistoryService paymentHistoryService, IPaymentService paymentService, IPetService petService) : Controller
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

        if (guardianDTO.Success)
        {
            guardianVM = guardianVM.ToVM(guardianDTO.Data);
        }
        else
        {
            //COLOCAR MENSAGEM DE ERRO AQUI
        }

        return View(guardianVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(GuardianVM model)
    {
        var message = model.Id != 0 ? Resources.Text.GuardianUpdateSucess : Resources.Text.GuardianAddSucess;
        model.Country = "BR";
        await guardianService.AddOrUpdateAsync(model.ToModel());

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

    [HttpGet]
    public async Task<IActionResult> Details(int id = 0, int IdPet = 0)
    {
        var guardianId = id > 0 ? id:0;

        if (IdPet != 0)
        {
            var pets = await petService.GetAllAsync();
            guardianId = pets.FirstOrDefault(c => c.Id == IdPet).GuardianId;
        }

        var guardian = await guardianService.GetByPetIdAsync(guardianId);

        return View(guardian);
    }

    [HttpPost]
    public async Task<IActionResult> AjaxDetails(int id)
    {
        var paymentHistory = new List<PaymentHistory?>();

        var payment = await paymentService.GetAllCompleteAsync(id);

        foreach (var item in payment.Data)
        {
            var paymentHistoryTemp = await paymentHistoryService.GetAllAsync(item.Id);
            paymentHistory.AddRange(paymentHistoryTemp);
        }

        var payments = new PaymentsListsVM();

        return View(payments.GetPayments(payment.Data, paymentHistory));
    }
}
