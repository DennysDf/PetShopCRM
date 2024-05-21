using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class ProcedureGroupRepository(PetShopDbContext context) : RepositoryBase<ProcedureGroup>(context), IProcedureGroupRepository
{
}
