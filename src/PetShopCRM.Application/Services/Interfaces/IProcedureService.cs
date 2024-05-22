using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IProcedureService
{
    Task<List<Procedure>> GetAllAsync();
    Task<List<Procedure>> GetAllWithHealthPlansAsync(int id = 0);
    Task<Procedure> AddOrUpdateAsync(Procedure benefit);
    Task<ResponseDTO<Procedure>> GetByIdAsync(int id);
    Task<ResponseDTO<Procedure>> GetByIdWithVinculatedHealthPlansAsync(int id);
    Task<bool> DeleteAsync(int id);
}