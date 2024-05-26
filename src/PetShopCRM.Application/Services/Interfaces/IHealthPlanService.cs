using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Payments;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IHealthPlanService
{    
    Task<List<HealthPlan>> GetAllAsync();
    Task<HealthPlan> AddOrUpdateAsync(HealthPlan guardin);
    Task<ResponseDTO<HealthPlan>> GetByIdAsync(int id);
    ResponseDTO<List<HealthPlan>> GetAllCompleteAsync(int id = 0);
    Task<bool> DeleteAsync(int id);
}
