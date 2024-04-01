using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Web.Models.Guardian;
using PetShopCRM.Web.Models.HealthPlans;
using PetShopCRM.Web.Services.Interfaces;

namespace PetShopCRM.Web.Controllers;


[Authorize]
public class HealthPlansController(
        ILoginService loginService,
        INotificationService notificationService,
        IHealthPlanService healthPlanService, ILoggedUserService loggedUserService,
        IUpload upload) : Controller
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
}
