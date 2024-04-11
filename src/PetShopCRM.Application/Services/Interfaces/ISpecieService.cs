using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Specie;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services.Interfaces;

public interface ISpecieService
{
    Task<List<Specie>> GetAllAsync();
    Task<Specie> AddOrUpdateAsync(Specie guardin);
    Task<ResponseDTO<Specie>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<List<SpeciePercentDTO>> GetPercent();
}
