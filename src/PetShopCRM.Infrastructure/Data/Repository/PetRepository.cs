using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class PetRepository(PetShopDbContext context) : RepositoryBase<Pet>(context), IPetRepository
{
}
