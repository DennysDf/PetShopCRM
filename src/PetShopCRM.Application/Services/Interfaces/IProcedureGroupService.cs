using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IProcedureGroupService
{
    Task<List<ProcedureGroup>> GetAllAsync();
    Task<ProcedureGroup> AddOrUpdateAsync(ProcedureGroup group);
    Task<ResponseDTO<ProcedureGroup>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
