using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.Repository;

public class UserRepository(PetShopDbContext context) : RepositoryBase<User>(context), IUserRepository
{
    public async Task<User?> GetByLoginAndPasswordAsync(string login, string password)
    {
        var user = (GetBy(x => x.Login.Equals(login) && x.Password.Equals(password))).FirstOrDefault();

        return user;
    }
}
