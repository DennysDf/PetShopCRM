﻿using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class PetService(IUnitOfWork unitOfWork) : IPetService
{
    public async Task<List<Pet>> GetAllAsync()
    {
        var guardians = await unitOfWork.PetRepository.GetByAsync();

        return guardians.ToList();
    }

    public async Task<ResponseDTO<List<Pet>>> GetAllCompleteAsync()
    {
        var pets = await unitOfWork.PetRepository.GetByAsync();

        var result = pets
            .Include(x => x.Guardian)
            .Include(x => x.Specie)
            .ToList();

        return new ResponseDTO<List<Pet>>(result.Count > 0, "Nenhum resultado encontrado", result);
    }

    public async Task<Pet> AddOrUpdateAsync(Pet model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.PetRepository.AddOrUpdateAsync(model);

        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<Pet>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.PetRepository.GetByIdAsync(id);
        return new ResponseDTO<Pet>(model != null, Resources.Message.PetNotFound, model);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var delete = await unitOfWork.PetRepository.DeleteOrRestoreAsync(id);

        return delete;
    }
}