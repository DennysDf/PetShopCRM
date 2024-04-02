using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Data.Repository.Interfaces;

public interface IGuardianRepository : IRepositoryBase<Guardian>
{
    Task<Guardian?> GetByPetIdAsync(int petId);
}
