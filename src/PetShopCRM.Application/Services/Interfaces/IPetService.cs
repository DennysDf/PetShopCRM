using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPetService
{
    Task<List<Pet>> GetAllAsync();
    Task<Pet> AddOrUpdateAsync(Pet guardin);
    Task<ResponseDTO<Pet>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
