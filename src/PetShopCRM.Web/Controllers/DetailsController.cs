using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Web.Models.Details;

namespace PetShopCRM.Web.Controllers;

[Authorize]
public class DetailsController(
    IPetService petService,
    IGuardianService guardianService,
    IHealthPlanService healthPlanService,
    IPaymentService paymentService,
    IRecordService recordService) : Controller
{
    public async Task<IActionResult> Pet(int id)
    {
        var pet = await petService.GetCompleteByIdAsync(id);

        var model = new DetailsPetVM();
        model.ToVM(pet.Data);

        return View(model);
    }

    public async Task<IActionResult> AjaxGuardian(int guardianId)
    {
        var guardianDTO = await guardianService.GetCompleteByIdAsync(guardianId);

        if (guardianDTO != null && guardianDTO.Success)
            return View(guardianDTO.Data);

        return Json(null);
    }

    public async Task<IActionResult> AjaxHealthPlan(int healthPlanId, int petId)
    {
        var healthPlanDTO = await healthPlanService.GetCompleteByIdAsync(healthPlanId);

        if (healthPlanDTO != null && healthPlanDTO.Success)
        {
            ViewData["RecordProcedures"] = (await recordService.GetAllUsesByPetAsync(petId)).Data;

            return View(healthPlanDTO.Data);
        }

        return Json(null);
    }

    public async Task<IActionResult> AjaxPayment(int paymentId)
    {
        var paymentDTO = await paymentService.GetCompleteByIdAsync(paymentId);

        if (paymentDTO != null && paymentDTO.Success)
            return View(paymentDTO.Data);

        return Json(null);
    }

    public async Task<IActionResult> AjaxRecord(int petId)
    {
        var recordsDTO = await recordService.GetAllCompleteByPetAsync(petId);

        if (recordsDTO != null && recordsDTO.Success)
            return View(recordsDTO.Data);

        return Json(null);
    }
}
