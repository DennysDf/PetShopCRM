using PetShopCRM.Application.DTOs.User;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Application.DTOs.Guardian;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Polly.Bulkhead;
using Microsoft.EntityFrameworkCore;

namespace PetShopCRM.Application.Services;

public class GuardianService(IUnitOfWork unitOfWork) : IGuardianService
{

    public async Task<List<Guardian>> GetAllAsync()
    {   
        var guardians = unitOfWork.GuardianRepository.GetBy(x => x.Active);

        return guardians.ToList();
    }

    public async Task<ResponseDTO<List<Guardian>>> GetAllCompleteAsync()
    {
        var guardians = unitOfWork.GuardianRepository.GetBy(x => x.Active).Include(c => c.Pets).ToList();

        return new ResponseDTO<List<Guardian>>(guardians.Count > 0, "Nenhum resultado encontrado", guardians);
    }

    public async Task<Guardian> AddOrUpdateAsync(Guardian model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.GuardianRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();

        return model;
    }

    public async Task<ResponseDTO<Guardian>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.GuardianRepository.GetByIdAsync(id);
        return new ResponseDTO<Guardian>(model != null, Resources.Message.GuardianNotFound, model);

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.GuardianRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }
 
    public async Task<Guardian?> GetByPetIdAsync(int id)
    {
        var guardian = await unitOfWork.GuardianRepository.GetByPetIdAsync(id);
        return guardian;
    }
}
