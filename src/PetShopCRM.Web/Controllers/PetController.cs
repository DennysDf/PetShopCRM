using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.Clinic;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Models.Pet;
using PetShopCRM.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;

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
        var petsComplete = await petService.GetAllCompleteAsync();

        return View(PetVM.ToList(petsComplete.Data));
    }

    public async Task<IActionResult> Ajax(int id)
    {
        var petDTO = await petService.GetByIdAsync(id);
        var petVM = new PetVM();

        if (petDTO.Success) 
        {
            petVM = petVM.ToVM(petDTO.Data);
        }
        
        var guardians = guardianService.GetAllAsync().Result.ToList();
        petVM.GuardianList = new SelectList(guardians.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList(), "Id", "Name");

        var species = specieService.GetAllAsync().Result.ToList();
        petVM.SpecieList = new SelectList(species.Select(c => new { c.Id, c.Name }).OrderBy(c => c.Name).ToList() , "Id", "Name");

        return View(petVM);
    }
     
    [HttpPost]
    public async Task<IActionResult> Index(PetVM model)
    {
        var message = model.Id != 0 ? Resources.Text.PetUpdateSucess : Resources.Text.PetAddSucess;
        Pet? pet;

        if (model.Id != 0)
        {
            var petDTO =  await petService.GetByIdAsync(model.Id);
            pet = model.ToModel(petDTO.Data);
        }
        else
        {
            pet = model.ToModel();
        }
        
        var photo = model.UrlPhoto;
        pet.UrlPhoto = model.Photo == null ? photo : upload.GetNameFile(model.Photo);

        if (model.Photo != null)
        {
            pet.UpdatedDateImg = DateTime.Now;
        }

        pet = await petService.AddOrUpdateAsync(pet);

        if (model.Photo != null) 
        {
            upload.SavePhotoPet(model.Photo, pet.Id);
        }

        notificationService.Success(message);

        if (model.Route.Equals("Guardian"))
        {
            return RedirectToAction("Details", "Guardian", new { IdPet = model.Id });
        }


        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<string> AjaxiImgPet(int id)
    {
        var petDTO = await petService.GetAllCompleteAsync();
        var petVM = new PetVM();

        if (petDTO.Success)
        {
            var pet = petDTO.Data.FirstOrDefault(c => c.Id == id);
            petVM = petVM.ToVM(pet);
            petVM.Specie = pet.Specie.Name;
            petVM.Guardian = pet.Guardian.Name;
        }


        return JsonConvert.SerializeObject(petVM);
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var pet = await petService.DeleteAsync(id);
        notificationService.Success(Resources.Text.PetDeleteSucess);

        return RedirectToAction("Index");
    }

}
