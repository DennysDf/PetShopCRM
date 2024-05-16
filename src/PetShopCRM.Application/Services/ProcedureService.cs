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

public class ProcedureService(IUnitOfWork unitOfWork) : IProcedureService
{
    public async Task<List<Benefit>> GetAllAsync()
    {
        var procedure = unitOfWork.ProcedureRepository.GetBy(x => x.Active).Include(c => c.Group).OrderBy(c => c.Procedure).ToList();
        


        return procedure.ToList();
    }

    public async Task<Benefit> AddOrUpdateAsync(Benefit model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.ProcedureRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<Benefit>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.ProcedureRepository.GetByIdAsync(id);
        return new ResponseDTO<Benefit>(model != null, Resources.Message.ProcedureNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.ProcedureRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }

}