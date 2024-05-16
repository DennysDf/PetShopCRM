using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IProcedureService
{
    Task<List<Benefit>> GetAllAsync();
    Task<Benefit> AddOrUpdateAsync(Benefit benefit);
    Task<ResponseDTO<Benefit>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}