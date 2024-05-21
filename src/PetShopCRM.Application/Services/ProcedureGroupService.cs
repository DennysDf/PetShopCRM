using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class ProcedureGroupService(IUnitOfWork unitOfWork) : IProcedureGroupService
{
    public async Task<List<ProcedureGroup>> GetAllAsync()
    {
        var groups = unitOfWork.ProcedureGroupRepository.GetBy(x => x.Active);

        return groups.ToList();
    }

    public async Task<ProcedureGroup> AddOrUpdateAsync(ProcedureGroup model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.ProcedureGroupRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<ProcedureGroup>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.ProcedureGroupRepository.GetByIdAsync(id);
        return new ResponseDTO<ProcedureGroup>(model != null, Resources.Message.ProcedureNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.ProcedureGroupRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }
}
