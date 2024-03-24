using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IGuardianRepository GuardianRepository { get; } 

    Task<int> SaveChangesAsync();
}
