using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class HealthPlansRepository(PetShopDbContext context) : RepositoryBase<HealthPlan>(context), IHealthPlansRepository
{

}
