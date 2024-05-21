using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class ProcedureRepository(PetShopDbContext context) : RepositoryBase<Procedure>(context), IProcedureRepository
{
}