using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Pet;
using PetShopCRM.Web.Models.Specie;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class SpecieController(
        ILoginService loginService,
        INotificationService notificationService,
        ISpecieService specieService, ILoggedUserService loggedUserService,
        IUpload upload) : Controller
{
    public async Task<IActionResult> Index()
    {
        var species = await specieService.GetAllAsync();

        var speciesVMList = new SpecieVM().ToList(species);

        return View(speciesVMList);
    }

    public async Task<IActionResult> Ajax(int id)
    {
        var petDTO = await specieService.GetByIdAsync(id);
        var specieVM = new SpecieVM();

        if (petDTO.Success)
        {
            specieVM = specieVM.ToVM(petDTO.Data);
        }
        else
        {
            //COLOCAR MENSAGEM DE ERRO AQUI
        }

        return View(specieVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(SpecieVM model)
    {
        var message = model.Id != 0 ? Resources.Text.PetUpdateSucess : Resources.Text.PetAddSucess;
        await specieService.AddOrUpdateAsync(model.ToModel());

        notificationService.Success(message);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await specieService.DeleteAsync(id);
        notificationService.Success(Resources.Text.PetDeleteSucess);

        return RedirectToAction("Index");
    }
}
