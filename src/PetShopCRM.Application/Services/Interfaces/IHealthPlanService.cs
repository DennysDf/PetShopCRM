using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IHealthPlanService
{    
    Task<List<HealthPlan>> GetAllAsync();
    Task<HealthPlan> AddOrUpdateAsync(HealthPlan guardin);
    Task<ResponseDTO<HealthPlan>> GetByIdAsync(int id);
    Task<bool> DeleteAsync(int id);
}
