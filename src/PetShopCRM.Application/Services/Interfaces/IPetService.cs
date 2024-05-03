using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPetService
{
    Task<List<Pet>> GetAllAsync();
    Task<ResponseDTO<List<Pet>>> GetAllCompleteAsync();
    Task<Pet> AddOrUpdateAsync(Pet guardin);
    Task<ResponseDTO<Pet>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<ResponseDTO<List<Pet>>> GetPetByGuardian(int id);
}
