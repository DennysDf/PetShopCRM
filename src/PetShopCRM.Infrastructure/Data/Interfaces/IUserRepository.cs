using PetShopCRM.Domain.Models;

namespace PetShopCRM.Infrastructure.Data.Interfaces;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<User> GetByLoginAndPasswordAsync(string login, string password);
}
