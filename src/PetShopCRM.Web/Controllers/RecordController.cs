using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.Record;

namespace PetShopCRM.Web.Controllers;

public class RecordController(IPetService petService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var pets = await petService.GetAllForPlansAsync();
        var recordVM = new RecordVM
        {
            ListPets = new SelectList(pets.Select(c => new { c.Id, Name = $"{c.Name} - {c.Identifier} - {c.Guardian.Name}" }).ToList(), nameof(Pet.Id), nameof(Pet.Name)),
            Date = DateTime.Now.ToDateBrazilMin().ToDateTime()
        };



        return View(recordVM);
    }
}
