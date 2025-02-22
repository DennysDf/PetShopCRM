﻿using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Specie;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class SpecieService(IUnitOfWork unitOfWork) : ISpecieService
{

    public async Task<List<Specie>> GetAllAsync()
    {
        var species = unitOfWork.SpecieRepository.GetBy(x => x.Active);

        return species.ToList();
    }

    public async Task<Specie> AddOrUpdateAsync(Specie model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.SpecieRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();

        return model;
    }

    public async Task<ResponseDTO<Specie>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.SpecieRepository.GetByIdAsync(id);
        return new ResponseDTO<Specie>(model != null, Resources.Message.SpecieNotFound, model);

    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.SpecieRepository.DeleteOrRestoreAsync(id);
        await unitOfWork.SaveChangesAsync();
        return delete;
    }

    public async Task<List<SpeciePercentDTO>> GetPercent()
    {
        var species = unitOfWork.SpecieRepository.GetBy();
        int petsQuantity = await unitOfWork.PetRepository.GetTotalByAsync();

        var result = species.Include(c => c.Pets)            
            .Select(c => new SpeciePercentDTO(c.Name, ((decimal)c.Pets.Count()/petsQuantity)*100 ))                        
                        .ToList();
        return result;
    }

}
