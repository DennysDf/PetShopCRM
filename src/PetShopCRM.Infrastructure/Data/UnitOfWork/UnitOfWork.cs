using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using PetShopCRM.Infrastructure.Data.Repository;
using PetShopCRM.Infrastructure.Data.Repository.Interfaces;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Infrastructure.Data.UnitOfWork;

public class UnitOfWork(PetShopDbContext dbContext) : IUnitOfWork
{
    private IUserRepository? _userRepository;
    private IGuardianRepository? _guardianRepository;
    private IClinicRepository ? _clinicRepository;
    private IPetRepository? _petRespository;
    private ISpecieRepository? _specieRepository;
    private IHealthPlansRepository? _healthPlansRepository;
    private IPaymentRepository? _paymentRepository;
    private IConfigurationRepository? _configurationRepository;

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(dbContext);
    public IGuardianRepository GuardianRepository => _guardianRepository ??= new GuardianRepository(dbContext);
    public IClinicRepository ClinicRepository => _clinicRepository ??= new ClinicRepository(dbContext);
    public IPetRepository PetRepository => _petRespository ??= new PetRepository(dbContext);
    public ISpecieRepository SpecieRepository => _specieRepository ??= new SpecieRepository(dbContext);
    public IHealthPlansRepository HealthPlansRepository => _healthPlansRepository ??= new HealthPlansRepository(dbContext);
    public IPaymentRepository PaymentRepository => _paymentRepository ??= new PaymentRepository(dbContext);
    public IConfigurationRepository ConfigurationRepository => _configurationRepository ??= new ConfigurationRepository(dbContext);


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
