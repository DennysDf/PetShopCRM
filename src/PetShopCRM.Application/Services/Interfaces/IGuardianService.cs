using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.Application.DTOs.Guardian;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IGuardianService
{
    Task<List<Guardian>> GetAllAsync();
    Task<ResponseDTO<Guardian>> GetByIdAsync(int id);
    Task<Guardian> AddAsync(Guardian guardin);
    Task<ResponseDTO<Guardian>> UpdateAsync(GuardianDTO modelGuardian);
    
}
