
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Clinic;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class ClinicController(
        ILoginService loginService,
        INotificationService notificationService,
        IClinicService clinicService, ILoggedUserService loggedUserService,
        IUpload upload) : Controller
{
    public async Task<IActionResult> Index()
    {
        var clinics = await clinicService.GetAllAsync();

        var clinicVMList = new ClinicVM().ToList(clinics);

        return View(clinicVMList);
    }

    public async Task<IActionResult> Ajax(int id)
    {
        var clinicDTO = await clinicService.GetByIdAsync(id);
        var clinicVM = new ClinicVM();

        if (clinicDTO.Success)
        {
            clinicVM = clinicVM.ToVM(clinicDTO.Data);
        }
        else
        {
            //COLOCAR MENSAGEM DE ERRO AQUI
        }

        return View(clinicVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ClinicVM model)
    {
        var message = model.Id != 0 ? Resources.Text.ClinicUpdateSucess : Resources.Text.ClinicAddSucess;
        await clinicService.AddOrUpdateAsync(model.ToModel());

        notificationService.Success(message);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var guardian = await clinicService.DeleteAsync(id);
        notificationService.Success(Resources.Text.ClinicDeleteSucess);

        return RedirectToAction("Index");
    }
}
