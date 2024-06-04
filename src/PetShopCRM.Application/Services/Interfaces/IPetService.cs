using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.DTOs.Report;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPetService
{
    Task<List<Pet>> GetAllAsync();
    Task<List<Pet>> GetAllWithoutActivePlanAsync();
    Task<ResponseDTO<List<Pet>>> GetAllCompleteAsync();
    Task<Pet> AddOrUpdateAsync(Pet guardin);
    Task<ResponseDTO<Pet>> GetByIdAsync(int id);
    Task<ResponseDTO<Pet>> GetCompleteByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    List<PetUpdateImgDTO>? GetPetsForUpdateImg();
    Task<List<Pet>> GetAllForPlansAsync();
}
