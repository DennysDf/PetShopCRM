using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Clinic;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Models.Pet;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class PetController(
        ILoginService loginService,
        INotificationService notificationService,
        IPetService petService, ILoggedUserService loggedUserService,
        IGuardianService guardianService,
        ISpecieService specieService,
        IUpload upload) : Controller
{
    public async Task<IActionResult> Index()
    {
        var pets = await petService.GetAllAsync();

        var petsVMList = new PetVM().ToList(pets);



        return View(petsVMList);
    }

    public async Task<IActionResult> Ajax(int id)
    {
        var petDTO = await petService.GetByIdAsync(id);
        var petVM = new PetVM();

        var guardians = guardianService.GetAllAsync().Result.ToList();
        petVM.GuardianList = new SelectList(guardians.Select(c => new { c.Id, c.Name }).ToList(), "Id", "Name");

        var species = specieService.GetAllAsync().Result.ToList();
        petVM.SpecieList = new SelectList(species.Select(c => new { c.Id, c.Name }).ToList(), "Id", "Name");

        if (petDTO.Success)
        {
            petVM = petVM.ToVM(petDTO.Data);
        }
        else
        {
            //COLOCAR MENSAGEM DE ERRO AQUI
        }

        return View(petVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(PetVM model)
    {
        var message = model.Id != 0 ? Resources.Text.PetUpdateSucess : Resources.Text.PetAddSucess;
        await petService.AddOrUpdateAsync(model.ToModel());

        notificationService.Success(message);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await petService.DeleteAsync(id);
        notificationService.Success(Resources.Text.PetDeleteSucess);

        return RedirectToAction("Index");
    }

}
