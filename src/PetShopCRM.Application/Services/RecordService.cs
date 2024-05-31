﻿using Microsoft.EntityFrameworkCore;
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

public class RecordService(IUnitOfWork unitOfWork) : IRecordService
{
    public async Task<Record> AddOrUpdateAsync(Record model)
    {
        ArgumentNullException.ThrowIfNull(model);
        model.Active = true;
        await unitOfWork.RecordRespository.AddOrUpdateAsync(model);
        await unitOfWork.SaveChangesAsync();
        return model;
    }

    public async Task<ResponseDTO<List<Record>>> GetAllCompleteAsync(int id = 0)
    {
        var record = unitOfWork.RecordRespository.GetBy(x => x.Active)
            .Include(c => c.Clinic)
            .Include(c => c.Pet)
                .ThenInclude(c => c.Specie)
            .Include(c => c.Pet)
                .ThenInclude(c => c.Guardian)
            .Include(c => c.ProcedureHealthPlan)
                .ThenInclude(c => c.Procedure)
            .Include(c => c.ProcedureHealthPlan)
                .ThenInclude(c => c.HealthPlan)
            .OrderBy(c => c.Date)
            .AsQueryable();

        if (id != 0)
            record = record.Where(c => c.Pet.GuardianId == id);

        return new ResponseDTO<List<Record>>(record.ToList().Count > 0, "Nenhum resultado encontrado", record.ToList());
    }


    public async Task<ResponseDTO<Record>> GetByIdAsync(int id)
    {
        var model = await unitOfWork.RecordRespository.GetByIdAsync(id);
        return new ResponseDTO<Record>(model != null, Resources.Message.RecordNotFound, model);
    }

}
