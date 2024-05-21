using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Procedure;
using PetShopCRM.Web.Services.Interfaces;
using System.Text.RegularExpressions;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class ProcedureController(
    INotificationService notificationService,
    IProcedureService procedureService,
    IProcedureGroupService procedureGroupService,
    IHealthPlanService healthPlanService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var procedures = await procedureService.GetAllAsync();

        var proceduresVM = new ProcedureVM().ToList(procedures);

        return View(proceduresVM);
    }

    public async Task<IActionResult> AjaxIndex(int Id = 0)
    {
        var procedure = await procedureService.GetByIdAsync(Id);
        var procedureVM = new ProcedureVM();

        if (procedure.Success)
            procedureVM = procedureVM.ToVM(procedure.Data);

        var groups = await procedureGroupService.GetAllAsync();
        procedureVM.GroupList = new SelectList(groups.Select(c => new { c.Id, Name = c.Description }).ToList(), "Id", "Name");

        return View(procedureVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(ProcedureVM model)
    {
        var message = model.Id != 0 ? Resources.Text.ProcedureUpdateSucess : Resources.Text.ProcedureAddSucess;
        await procedureService.AddOrUpdateAsync(model.ToModel());

        notificationService.Success(message);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteProcedure(int id)
    {
        var plan = await procedureService.DeleteAsync(id);
        notificationService.Success(Resources.Text.ProcedureDeleteSucess);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Group()
    {
        var groups = await procedureGroupService.GetAllAsync();

        var groupsVM = new ProcedureGroupVM().ToList(groups);

        return View(groupsVM);
    }

    public async Task<IActionResult> AjaxGroup(int Id = 0)
    {
        var group = await procedureGroupService.GetByIdAsync(Id);
        var groupVM = new ProcedureGroupVM();

        if (group.Success)
            groupVM = groupVM.ToVM(group.Data);

        return View(groupVM);
    }

    [HttpPost]
    public async Task<IActionResult> Group(ProcedureGroupVM model)
    {
        var message = model.Id != 0 ? Resources.Text.ProcedureGroupUpdateSucess : Resources.Text.ProcedureGroupAddSucess;
        await procedureGroupService.AddOrUpdateAsync(model.ToModel());

        notificationService.Success(message);

        return RedirectToAction(nameof(Group));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteGroup(int id)
    {
        var plan = await procedureGroupService.DeleteAsync(id);
        notificationService.Success(Resources.Text.ProcedureGroupDeleteSucess);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> HealthPlan()
    {
        var procedures = await procedureService.GetAllWithHealthPlansAsync();

        var procedureHealthPlansVM = new ProcedureHealthPlanVM().ToList(procedures);

        return View(procedureHealthPlansVM);
    }

    public async Task<IActionResult> AjaxHealthPlan(int procedureId = 0)
    {
        var procedure = await procedureService.GetByIdWithVinculatedHealthPlansAsync(procedureId);
        var procedureHealthPlanVM = new ProcedureHealthPlanVM { ProcedureId = procedureId };

        if (procedure.Success)
            procedureHealthPlanVM = procedureHealthPlanVM.ToVM(procedure.Data);

        var healthPlans = await healthPlanService.GetAllAsync();
        
        if(procedureHealthPlanVM.ProcedureHealthPlanList == null || !healthPlans.All(x => procedureHealthPlanVM.ProcedureHealthPlanList.Select(x => x.HealthPlanId).Contains(x.Id)))
        {
            procedureHealthPlanVM.ProcedureHealthPlanList ??= [];

            var healthPlansExcept = healthPlans.Where(x => !procedureHealthPlanVM.ProcedureHealthPlanList.Select(x => x.HealthPlanId).Contains(x.Id)).ToList();

            foreach(var healthPlan in healthPlansExcept)
            {
                procedureHealthPlanVM.ProcedureHealthPlanList.Add(new ProcedureHealthPlanListVM
                {
                    HealthPlanId = healthPlan.Id,
                    HealthPlanName = healthPlan.Name,
                    HealthPlanValue = healthPlan.Value
                });
            }
        }

        var procedures = await procedureService.GetAllAsync();

        var procedureGroupSelectList = procedures
            .Select(x => x.ProcedureGroup.Description)
            .Distinct()
            .Select(x => new SelectListGroup { Name = x })
            .ToList();

        var proceduresSelectListItems = procedures
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Description,
                Group = procedureGroupSelectList.First(d => d.Name == x.ProcedureGroup.Description)
            }).ToList();

        procedureHealthPlanVM.ProcedureList = new SelectList(
            proceduresSelectListItems,
            "Value",
            "Text",
            procedureId,
            "Group.Name");

        procedureHealthPlanVM.ProcedureHealthPlanList = procedureHealthPlanVM.ProcedureHealthPlanList.OrderBy(x => x.HealthPlanId).ToList();

        return View(procedureHealthPlanVM);
    }

    [HttpPost]
    public async Task<IActionResult> HealthPlan(ProcedureHealthPlanVM model)
    {
        var procedureDTO = await procedureService.GetByIdWithVinculatedHealthPlansAsync(model.ProcedureId);

        if (procedureDTO is null)
        {
            return RedirectToAction(nameof(HealthPlan));
        }

        var procedure = model.ToModel(procedureDTO.Data);
        await procedureService.AddOrUpdateAsync(procedure);

        notificationService.Success(Resources.Text.ProcedureHealthPlanSuccess);

        return RedirectToAction(nameof(HealthPlan));
    }
}
