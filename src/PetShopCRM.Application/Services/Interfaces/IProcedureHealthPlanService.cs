using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IProcedureHealthPlanService
{
    Task<List<ProcedureHealthPlan>> GetAllAsync();
    Task<ProcedureHealthPlan> AddOrUpdateAsync(ProcedureHealthPlan model);
    Task<ResponseDTO<ProcedureHealthPlan>> GetByIdAsync(int healthPlanId = 0);
    Task<bool> DeleteAsync(int id);
    Task<ResponseDTO<List<ProcedureHealthPlan>>> GetAllCompleteAsync(int id = 0);
}
