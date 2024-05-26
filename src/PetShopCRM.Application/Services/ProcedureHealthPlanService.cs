using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services;

public class ProcedureHealthPlanService(IUnitOfWork unitOfWork) : IProcedureHealthPlanService
{
    public async Task<List<ProcedureHealthPlan>> GetAllAsync()
    {
        var procedureHealthPlan = unitOfWork.ProcedureHealthPlanRepository.GetBy(x => x.Active);
        return procedureHealthPlan.ToList();
    }

    public async Task<ResponseDTO<List<ProcedureHealthPlan>>> GetAllCompleteAsync(int healthPlanId = 0)
    {
        var procedureHealthPlan = unitOfWork.ProcedureHealthPlanRepository.GetBy(x => x.Active)
            .Include(c => c.Procedure)
            .AsQueryable();

        if (healthPlanId != 0)
            procedureHealthPlan = procedureHealthPlan.Where(c => c.HealthPlanId == healthPlanId);

        return new ResponseDTO<List<ProcedureHealthPlan>>(procedureHealthPlan.ToList().Count > 0, "Nenhum resultado encontrado", procedureHealthPlan.ToList());
    }

    public async Task<ProcedureHealthPlan> AddOrUpdateAsync(ProcedureHealthPlan model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.ProcedureHealthPlanRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();

        return model;
    }

    public async Task<ResponseDTO<ProcedureHealthPlan>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.ProcedureHealthPlanRepository.GetByIdAsync(id);
        return new ResponseDTO<ProcedureHealthPlan>(model != null, Resources.Message.ProcedurePlanNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.GuardianRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }
}
