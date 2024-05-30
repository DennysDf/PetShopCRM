using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.HealthPlans;
using PetShopCRM.Web.Models.Record;
using PetShopCRM.Web.Services;
using PetShopCRM.Web.Services.Interfaces;
using System.Text.Json;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class RecordController(  IPetService petService, 
                                IProcedureHealthPlanService procedureHealthPlanService , 
                                IPaymentService paymentService,
                                IHealthPlanService healthPlanService,
                                IRecordService recordService,
                                INotificationService notificationService,
                                IClinicService clinicService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var pets = await petService.GetAllForPlansAsync();
        var healthPlan = await healthPlanService.GetAllAsync();
        var clinics = await clinicService.GetAllAsync();
        //var clinics = 
        var  recordVM = new RecordVM
        {
            ListPets = new SelectList(pets.Select(c => new { c.Id, Name = $"{c.Name} - {c.Identifier} - {c.Guardian.Name}" }).ToList(), nameof(Pet.Id), nameof(Pet.Name)),
            Date = DateTime.Now.ToDateBrazilMin().ToDateTime(),
            ListHealthPlan = new SelectList(healthPlan.Select(c => new { c.Id, Name = $"{c.Name} - R$ {c.Value}" }).ToList(), nameof(HealthPlan.Id), nameof(HealthPlan.Name)),
            ListClinics = new SelectList(clinics.Select(c => new { c.Id, Name = $"{c.Name}" }).ToList(), nameof(Clinic.Id), nameof(Clinic.Name)),
        };

        return View(recordVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(RecordVM modelVM)
    {
        var message = modelVM.Id != 0 ? Resources.Text.RecordUpdateSucess : Resources.Text.RecordAddSucess;
        var model = modelVM.ToModel(modelVM);
        await recordService.AddOrUpdateAsync(model);
        notificationService.Success(message);
        return RedirectToAction("List");
    }

    public async Task<string> GetProcedureByPet(int id)
    {
        var options = new JsonSerializerOptions
        {
            ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve
        };

        var planIdCreate = paymentService.GetPlanByPet(id);
        var json = string.Empty;
        var proceduresDTO = await procedureHealthPlanService.GetAllCompleteAsync(planIdCreate.Id);

        if (proceduresDTO.Success)
        {
            var procedure = proceduresDTO.Data;
            var teste = procedure.Where(c => c.Lack <= (DateTime.Now - planIdCreate.DateCreate).Days );
            json = JsonSerializer.Serialize(teste, options);
        }

        return json;
    }

    public async Task<IActionResult> List()
    {
        var records = new List<Record>();
        var recordsDTO = await recordService.GetAllCompleteAsync();
        if (recordsDTO.Success)
        {
            records = recordsDTO.Data;
        }

        return View(records);
    }

    public async Task<IActionResult> Details(int id)
    {
        var recordDTO = await recordService.GetAllCompleteAsync(id);
        var recordVM = new RecordVM();

        if (recordDTO.Success)
        {
            var record = recordDTO.Data;
            recordVM = recordVM.ToVM(record);
        }

        return View(recordVM);
    }

}
