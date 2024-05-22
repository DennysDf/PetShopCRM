using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class HealthPlanService(IUnitOfWork unitOfWork) : IHealthPlanService
{
    public async Task<List<HealthPlan>> GetAllAsync()
    {
        var healthPlans = unitOfWork.HealthPlansRepository.GetBy(x => x.Active);

        return healthPlans.ToList();
    }

    public async Task<HealthPlan> AddOrUpdateAsync(HealthPlan model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.HealthPlansRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<HealthPlan>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.HealthPlansRepository.GetByIdAsync(id);
        return new ResponseDTO<HealthPlan>(model != null, Resources.Message.GuardianNotFound, model);
    }

    public async Task<ResponseDTO<List<HealthPlan>>> GetAllCompleteAsync(int id = 0)
    {
        var healthPlans = unitOfWork.HealthPlansRepository.GetBy(x => x.Active)
            .Include(c => c.ProcedureHealthPlans)                
                .ThenInclude(c => c.Procedure)
                    .ThenInclude(c => c.ProcedureGroup)
            .AsQueryable();

        if (id != 0)
            healthPlans = healthPlans.Where(c => c.Id == id);

        return new ResponseDTO<List<HealthPlan>>(healthPlans.ToList().Count > 0, "Nenhum resultado encontrado", healthPlans.ToList());
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.HealthPlansRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }
}
