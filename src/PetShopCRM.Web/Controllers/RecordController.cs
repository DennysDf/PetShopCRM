using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.Procedure;
using PetShopCRM.Web.Models.Record;
using PetShopCRM.Web.Services.Interfaces;
using System.Text.Json;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class RecordController(IPetService petService,
                                IProcedureHealthPlanService procedureHealthPlanService,
                                IPaymentService paymentService,
                                IHealthPlanService healthPlanService,
                                IRecordService recordService,
                                INotificationService notificationService,
                                IClinicService clinicService,
                                ILoggedUserService loggedUserService,
                                IUserService userService) : Controller
{
    public async Task<IActionResult> Index(int id = 0, string? route = null)
    {
        var recordVM = new RecordVM
        {
            Id = id,
            Route = route
        };

        return View(recordVM);
    }

    [HttpPost]
    public async Task<IActionResult> AjaxForm(RecordVM model)
    {
        if (model.Id == 0)
        {
            model.Date = DateTime.Now.ToDateBrazilMin().ToDateTime();
        }
        else
        {
            var recordDTO = await recordService.GetByIdAsync(model.Id);
            if (recordDTO.Success)
                model = model.ToVM(recordDTO.Data);
        }

        var clinics = await clinicService.GetAllAsync();
        var pets = await petService.GetAllForPlansAsync();

        model.ListPets = new SelectList(pets.Select(c => new { c.Id, Name = $"{c.Name} - {c.Identifier} - {c.Guardian.Name}" }).ToList(), nameof(Pet.Id), nameof(Pet.Name));
        model.ListClinics = new SelectList(clinics.Select(c => new { c.Id, Name = $"{c.Name}" }).ToList(), nameof(Clinic.Id), nameof(Clinic.Name));

        if (model.PetId != 0)
        {
            var healthPlan = await healthPlanService.GetAllAsync();
            model.ListHealthPlan = new SelectList(healthPlan.Select(c => new { c.Id, Name = $"{c.Name} - R$ {c.Value}" }).ToList(), nameof(HealthPlan.Id), nameof(HealthPlan.Name));

            var planIdCreate = paymentService.GetPlanByPet(model.PetId);

            if (model.HealthPlanId == 0)
                model.HealthPlanId = planIdCreate.Id;

            var recordProceduresDTO = await recordService.GetAllUsesByPetAsync(model.PetId);

            var proceduresHealthPlanDTO = await procedureHealthPlanService.GetAllCompleteAsync(model.HealthPlanId);
            var procedures = proceduresHealthPlanDTO.Data.Where(c => c.Lack <= (DateTime.Now - planIdCreate.DateCreate).Days);

            var procedureGroupSelectList = procedures
                .Select(x => x.Procedure.ProcedureGroup.Description)
                .Distinct()
                .Select(x => new SelectListGroup { Name = x })
                .ToList();

            var proceduresSelectListItems = procedures
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = $"{c.Procedure.Description} | {(c.CoparticipationUnit == ProcedureCoparticipationUnit.Value ? $"R$ {c.Coparticipation}" : $"{c.Coparticipation}%")} | {(recordProceduresDTO.Data.FirstOrDefault(x => x.ProcedureId == c.ProcedureId)?.Quantity ?? 0)}/{(c.AnnualLimit?.ToString() ?? "Ilimitado")}",
                    Group = procedureGroupSelectList.First(d => d.Name == c.Procedure.ProcedureGroup.Description)
                }).ToList();

            model.ListProcedureHealthPlan = new SelectList(
                proceduresSelectListItems,
                "Value",
                "Text",
                model.ProcedureHealthPlanId,
                "Group.Name");
        }

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(RecordVM modelVM)
    {
        var message = modelVM.Id != 0 ? Resources.Text.RecordUpdateSucess : Resources.Text.RecordAddSucess;

        Record model = new();
        if (modelVM.Id == 0)
        {
            model = modelVM.ToModel(model);
        }
        else
        {
            var dto = await recordService.GetByIdAsync(modelVM.Id);
            model = modelVM.ToModel(dto.Data);
        }

        await recordService.AddOrUpdateAsync(model);
        notificationService.Success(message);

        if (modelVM.Route != null)
            return RedirectToAction("Pet", "Details", new { id = modelVM.PetId });

        return RedirectToAction("List");
    }

    public async Task<IActionResult> List()
    {
        var records = new List<Record>();
        int id = 0;
        if (loggedUserService.Role == nameof(UserType.Guardian))
        {
            var userDTO = await userService.GetUserByIdAsync(loggedUserService.Id);
            id = (int)userDTO.Data.GuardianId;
        }

        var recordsDTO = await recordService.GetAllCompleteByGuardianAsync(id);
        if (recordsDTO.Success)
        {
            records = recordsDTO.Data;
        }

        return View(records);
    }

    public async Task<IActionResult> AjaxDetails(int id)
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
