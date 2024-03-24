using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class ClinicRepository(PetShopDbContext context) : RepositoryBase<Clinic>(context), IClinicRepository
{
}
