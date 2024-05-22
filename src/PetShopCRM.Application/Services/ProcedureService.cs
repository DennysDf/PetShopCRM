using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class ProcedureService(IUnitOfWork unitOfWork) : IProcedureService
{
    public async Task<List<Procedure>> GetAllAsync()
    {
        var procedures = await unitOfWork.ProcedureRepository
            .GetBy(x => x.Active)
            .Include(c => c.ProcedureGroup)
            .OrderBy(c => c.Description)
            .ToListAsync();
        
        return procedures;
    }

    public async Task<List<Procedure>> GetAllWithHealthPlansAsync(int id = 0)
    {
        var procedures = await unitOfWork.ProcedureRepository
            .GetBy(x => x.Active)
            .Include(c => c.ProcedureGroup)
            .Include(c => c.ProcedureHealthPlans.Where(x => x.Active))
                .ThenInclude(x => x.HealthPlan)
            .OrderBy(c => c.Description)
            .Where(x => x.ProcedureHealthPlans.Any(x => x.Active ))
            .ToListAsync();

        return procedures;
    }

    public async Task<Procedure> AddOrUpdateAsync(Procedure model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.ProcedureRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<Procedure>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.ProcedureRepository.GetByIdAsync(id);
        return new ResponseDTO<Procedure>(model != null, Resources.Message.ProcedureNotFound, model);
    }

    public async Task<ResponseDTO<Procedure>> GetByIdWithVinculatedHealthPlansAsync(int id)
    {
        var model = await unitOfWork.ProcedureRepository.GetBy(x => x.Id == id)
            .Include(x => x.ProcedureHealthPlans)
                .ThenInclude(x => x.HealthPlan)
            .FirstOrDefaultAsync();

        return new ResponseDTO<Procedure>(model != null, Resources.Message.ProcedureNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.ProcedureRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }

}