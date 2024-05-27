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
}
