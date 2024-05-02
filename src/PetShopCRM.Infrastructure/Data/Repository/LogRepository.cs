using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class LogRepository(PetShopDbContext context) : RepositoryBase<Log>(context), ILogRepository
{
}
