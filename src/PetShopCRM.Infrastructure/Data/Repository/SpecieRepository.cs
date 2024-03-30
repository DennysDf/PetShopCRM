using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class SpecieRepository(PetShopDbContext context) : RepositoryBase<Specie>(context), ISpecieRepository
{
}
