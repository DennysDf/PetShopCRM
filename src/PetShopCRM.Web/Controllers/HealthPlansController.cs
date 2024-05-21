using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.HealthPlans;
using PetShopCRM.Web.Models.Procedure;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class HealthPlansController(
        ILoginService loginService,
        INotificationService notificationService,
        IHealthPlanService healthPlanService, ILoggedUserService loggedUserService,
        IUpload upload, IProcedureService proceduresService, IProcedureGroupService groupService) : Controller
{

    public async Task<IActionResult> Index()
    {
        var healthPlans = await healthPlanService.GetAllAsync();

        var healthPlansVMList = new HealthPlansVM().ToList(healthPlans);

        return View(healthPlansVMList);
    }

    public async Task<IActionResult> Ajax(int id)
    {
        var healthPlansDTO = await healthPlanService.GetByIdAsync(id);
        var healthPlansVM = new HealthPlansVM();

        if (healthPlansDTO.Success)
        {
            healthPlansVM = healthPlansVM.ToVM(healthPlansDTO.Data);
        }
        else
        {
            //COLOCAR MENSAGEM DE ERRO AQUI
        }

        return View(healthPlansVM);
    }

    [HttpPost]
    public async Task<IActionResult> Index(HealthPlansVM model)
    {
        var message = model.Id != 0 ? Resources.Text.HealthPlanUpdateSucess : Resources.Text.HealthPlanAddSucess;
        model.Value = model.ValueFrontEnd.StringToDecimal();
        await healthPlanService.AddOrUpdateAsync(model.ToModel());

        notificationService.Success(message);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var plan = await healthPlanService.DeleteAsync(id);
        notificationService.Success(Resources.Text.HealthPlanDeleteSucess);

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Procedures()
    {
        var benefits = await proceduresService.GetAllAsync();

        var benefitsVMList = new ProcedureVM().ToList(benefits);

        return View(benefitsVMList);

    }

    public async Task<IActionResult> AjaxProcedures(int Id = 0)
    {

        var procedures = await proceduresService.GetByIdAsync(Id);        
        var proceduresVM = new ProcedureVM();

        if (procedures.Success)
        {
            proceduresVM = proceduresVM.ToVM(procedures.Data);
        }

        var groups = await groupService.GetAllAsync();
        proceduresVM.GroupList = new SelectList(groups.Select(c => new { c.Id, Name = c.Description }).ToList(), "Id", "Name");

        return View(proceduresVM);
    }

    [HttpPost]
    public async Task<IActionResult> Procedures(ProcedureVM model)
    {
        var message = model.Id != 0 ? Resources.Text.ProcedureUpdateSucess : Resources.Text.ProcedureAddSucess;        
        await proceduresService.AddOrUpdateAsync(model.ToModel());
        notificationService.Success(message);

        return RedirectToAction("Procedures");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteProcedure(int id)
    {
        var plan = await proceduresService.DeleteAsync(id);
        notificationService.Success(Resources.Text.ProcedureDeleteSucess);

        return RedirectToAction("Index");
    }

}
