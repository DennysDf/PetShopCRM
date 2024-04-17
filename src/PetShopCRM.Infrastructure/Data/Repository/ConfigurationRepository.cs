using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class ConfigurationRepository(PetShopDbContext context) : RepositoryBase<Configuration>(context), IConfigurationRepository
{
}
