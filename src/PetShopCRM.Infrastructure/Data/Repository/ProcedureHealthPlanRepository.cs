using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class ProcedureHealthPlanRepository(PetShopDbContext context) : RepositoryBase<ProcedureHealthPlan>(context), IProcedureHealthPlanRepository
{
}
