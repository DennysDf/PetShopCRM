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

namespace PetShopCRM.Application.Services;

public class GuardianService(IUnitOfWork unitOfWork) : IGuardianService
{

    public async Task<List<Guardian>> GetAllAsync()
    {

        //colocar filtro de apenas o ativos
        var guardians = await unitOfWork.GuardianRepository.GetByAsync();

        return guardians.ToList();
    }

    public async Task<Guardian> AddAsync(Guardian guardian)
    {
        ArgumentNullException.ThrowIfNull(guardian);

        await unitOfWork.GuardianRepository.AddOrUpdateAsync(guardian);

        await unitOfWork.SaveChangesAsync();

        return guardian;
    }

    public async Task<ResponseDTO<Guardian>> GetByIdAsync(int id)
    {
        var guardian = await unitOfWork.GuardianRepository.GetByIdAsync(id);
        return new ResponseDTO<Guardian>(guardian != null, Resources.Message.UserNotFound, guardian);

    }

    Task<ResponseDTO<Guardian>> IGuardianService.UpdateAsync(GuardianDTO modelProfile)
    {
        throw new NotImplementedException();
    }

    //public async Task<ResponseDTO<User>> UpdateAsync(GuardianDTO modelProfile)
    //{
    //    var userDb = await unitOfWork.GuardianRepository.GetByIdAsync(modelProfile.Id);


    //    try
    //    {
    //        var user = await unitOfWork.UserRepository.AddOrUpdateAsync(userDb);
    //        await unitOfWork.SaveChangesAsync();

    //        return new ResponseDTO<User>(true, Resources.Message.UserSucessUpdate, user);
    //    }
    //    catch (Exception ex)
    //    {
    //        return new ResponseDTO<User>(false, ex.Message, null);
    //    }

    //}
}
