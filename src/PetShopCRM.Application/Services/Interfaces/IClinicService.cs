
using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces
{
    public interface IClinicService
    {
        Task<List<Clinic>> GetAllAsync();
        Task<Clinic> AddOrUpdateAsync(Clinic guardin);
        Task<ResponseDTO<Clinic>> GetByIdAsync(int id);
        Task<bool> DeleteAsync(int id);
    }
}
