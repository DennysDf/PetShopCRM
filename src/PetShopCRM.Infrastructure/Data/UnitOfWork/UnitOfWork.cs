using Microsoft.EntityFrameworkCore;
using PetShopCRM.Infrastructure.Data.Repository;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Infrastructure.Data.UnitOfWork;

public class UnitOfWork(PetShopDbContext dbContext) : IUnitOfWork
{
    private IUserRepository? _userRepository;
    private IGuardianRepository? _guardianRepository;
    public IUserRepository UserRepository => _userRepository ??= new UserRepository(dbContext);

    public IGuardianRepository GuardianRepository => _guardianRepository ??= new GuardianRepository(dbContext);

    public async Task<int> SaveChangesAsync()
    {
        return await dbContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
        {
            dbContext.Dispose();
        }
    }
}
