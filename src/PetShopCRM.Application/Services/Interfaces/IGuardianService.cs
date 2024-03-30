using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.Application.DTOs.Guardian;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IGuardianService
{
    Task<List<Guardian>> GetAllAsync();
    Task<Guardian> AddOrUpdateAsync(Guardian guardin);
    Task<ResponseDTO<Guardian>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
