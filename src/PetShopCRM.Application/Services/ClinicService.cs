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

public class ClinicService(IUnitOfWork unitOfWork) : IClinicService
{
    public async Task<List<Clinic>> GetAllAsync()
    {
        var clinics = unitOfWork.ClinicRepository.GetBy(x => x.Active);

        return clinics.ToList();
    }

    public async Task<Clinic> AddOrUpdateAsync(Clinic model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.ClinicRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<Clinic>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.ClinicRepository.GetByIdAsync(id);
        return new ResponseDTO<Clinic>(model != null, Resources.Message.UserNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.ClinicRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }
}
