using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services;

public class GroupService(IUnitOfWork unitOfWork) : IGroupService
{
    public async Task<List<Group>> GetAllAsync()
    {
        var groups = unitOfWork.GroupRespository.GetBy(x => x.Active);

        return groups.ToList();
    }

    public async Task<Group> AddOrUpdateAsync(Group model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.GroupRespository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<Group>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.GroupRespository.GetByIdAsync(id);
        return new ResponseDTO<Group>(model != null, Resources.Message.ProcedureNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.GroupRespository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }
}
