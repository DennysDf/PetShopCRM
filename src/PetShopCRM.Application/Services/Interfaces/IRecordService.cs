using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IRecordService
{
    Task<Record> AddOrUpdateAsync(Record record);
}
