using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class GuardianRepository(PetShopDbContext context) : RepositoryBase<Guardian>(context), IGuardianRepository
{

}
