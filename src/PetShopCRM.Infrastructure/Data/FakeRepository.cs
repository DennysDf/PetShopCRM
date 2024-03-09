using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Interfaces;

namespace PetShopCRM.Infrastructure.Data;

public class FakeRepository(PetShopDbContext context) : RepositoryBase<Fake>(context), IFakeRepository
{
}
