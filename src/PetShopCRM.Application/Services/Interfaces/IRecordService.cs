using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IRecordService
{
    Task<Record> AddOrUpdateAsync(Record record);
    Task<ResponseDTO<List<Record>>> GetAllCompleteAsync(int id = 0);
    Task<ResponseDTO<List<Record>>> GetAllCompleteByGuardianAsync(int guardianId);
    Task<ResponseDTO<Record>> GetByIdAsync(int id);
    Task<ResponseDTO<List<Record>>> GetAllCompleteByPetAsync(int petId);
}
