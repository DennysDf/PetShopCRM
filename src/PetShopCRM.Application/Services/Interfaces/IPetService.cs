using Azure;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.DTOs.Report;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPetService
{
    Task<List<Pet>> GetAllAsync();
    Task<ResponseDTO<List<Pet>>> GetAllCompleteAsync();
    Task<Pet> AddOrUpdateAsync(Pet guardin);
    Task<ResponseDTO<Pet>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
    Task<ResponseDTO<List<Pet>>> GetPetByGuardian(int id);

    List<PetUpdateImgDTO>? GetPetsForUpdateImg();
}
