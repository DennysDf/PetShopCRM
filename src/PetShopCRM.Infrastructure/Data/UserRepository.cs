using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Interfaces;

namespace PetShopCRM.Infrastructure.Data;

public class UserRepository(PetShopDbContext context) : RepositoryBase<User>(context), IUserRepository
{
    public async Task<User?> GetByLoginAndPasswordAsync(string login, string password)
    {
        var user = (await base.GetByAsync(x => x.Login.Equals(login) && x.Password.Equals(password))).FirstOrDefault();

        return user;
    }
}
