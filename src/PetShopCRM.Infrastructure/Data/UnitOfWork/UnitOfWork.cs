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
    private IPetRepository? _petRepository;
    private ISpecieRepository? _specieRepository;
    private IHealthPlansRepository? _healthPlansRepository;
    private IPaymentRepository? _paymentRepository;
    private IConfigurationRepository? _configurationRepository;
    private IPaymentHistoryRepository? _paymentHistoryRepository;
    private ILogRepository? _logRepository;
    private IProcedureRepository? _procedureRepository;
    private IProcedureGroupRepository? _procedureGroupRepository;
    private IProcedureHealthPlanRepository? _procedureHealthPlanRepository;
    private IRecordRespository _recordRespository;

    public IUserRepository UserRepository => _userRepository ??= new UserRepository(dbContext);
    public IGuardianRepository GuardianRepository => _guardianRepository ??= new GuardianRepository(dbContext);
    public IClinicRepository ClinicRepository => _clinicRepository ??= new ClinicRepository(dbContext);
    public IPetRepository PetRepository => _petRepository ??= new PetRepository(dbContext);
    public ISpecieRepository SpecieRepository => _specieRepository ??= new SpecieRepository(dbContext);
    public IHealthPlansRepository HealthPlansRepository => _healthPlansRepository ??= new HealthPlansRepository(dbContext);
    public IPaymentRepository PaymentRepository => _paymentRepository ??= new PaymentRepository(dbContext);
    public IConfigurationRepository ConfigurationRepository => _configurationRepository ??= new ConfigurationRepository(dbContext);
    public IPaymentHistoryRepository PaymentHistoryRepository => _paymentHistoryRepository ??= new PaymentHistoryRepository(dbContext);
    public ILogRepository LogRepository => _logRepository ??= new LogRepository(dbContext);
    public IProcedureRepository ProcedureRepository => _procedureRepository ??= new ProcedureRepository(dbContext);
    public IProcedureGroupRepository ProcedureGroupRepository => _procedureGroupRepository ??= new ProcedureGroupRepository(dbContext);
    public IProcedureHealthPlanRepository ProcedureHealthPlanRepository => _procedureHealthPlanRepository ??= new ProcedureHealthPlanRepository(dbContext);
    public IRecordRespository RecordRespository => _recordRespository ??= new RecordRepository(dbContext);

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
