using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.Application.DTOs.Guardian;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IGuardianService
{
    Task<List<Guardian>> GetAllAsync();
    Task<Guardian> AddOrUpdateAsync(Guardian guardin);
    Task<ResponseDTO<Guardian>> GetByIdAsync(int id);
    Task<ResponseDTO<Guardian>> GetCompleteByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<ResponseDTO<List<Guardian>>> GetAllCompleteAsync(int id = 0);
    Task<Guardian?> GetByPetIdAsync(int id);
    ResponseDTO<Guardian> GetByCPForEmail(string model);
}
