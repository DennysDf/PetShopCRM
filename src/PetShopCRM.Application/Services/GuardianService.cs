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
        var guardians = unitOfWork.GuardianRepository.GetBy(x => x.Active).OrderBy(c => c.Name);

        return guardians.ToList();
    }

    public async Task<ResponseDTO<List<Guardian>>> GetAllCompleteAsync(int id = 0)
    {
        var guardians = unitOfWork.GuardianRepository.GetBy(x => x.Active)
            .Include(c => c.Pets)
                .ThenInclude(c => c.Specie)
            .Include(c => c.Pets)
                .ThenInclude(c => c.Payments)
                    .ThenInclude(c => c.HealthPlan)
            .OrderBy(c => c.Name)
            .AsQueryable();

        if (id != 0)
            guardians = guardians.Where(c => c.Id == id);

        return new ResponseDTO<List<Guardian>>(guardians.ToList().Count > 0, "Nenhum resultado encontrado", guardians.ToList());
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

    public ResponseDTO<Guardian> GetByCPForEmail(string model)
    {
        var users = unitOfWork.GuardianRepository.GetBy();
        var user = users.Where(c => (c.CPF == model || c.Email == model) && c.Active);
        Guardian userModel = null;
        var email = string.Empty;

        if (user.Any())
        {
            userModel = user.First();
            email = userModel.Email;
        }

        return new ResponseDTO<Guardian>(user.Any(), email, userModel);

    }
}
