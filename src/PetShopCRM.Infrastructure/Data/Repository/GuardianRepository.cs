using Microsoft.EntityFrameworkCore;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class GuardianRepository(PetShopDbContext context) : RepositoryBase<Guardian>(context), IGuardianRepository
{
    public async Task<Guardian?> GetByPetIdAsync(int petId)
    {
        var guardian = GetBy(x => x.Pets.Any(s => s.Id == petId))
            .Include(x => x.Pets)
            .FirstOrDefault();

        return guardian;
    }
}
