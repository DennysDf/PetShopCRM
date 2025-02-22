﻿using PetShopCRM.Infrastructure.Data.Repository.Interfaces;

namespace PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IGuardianRepository GuardianRepository { get; }
    IClinicRepository ClinicRepository { get; }
    IPetRepository PetRepository { get; }
    ISpecieRepository SpecieRepository { get; }
    IHealthPlansRepository HealthPlansRepository { get; }
    IPaymentRepository PaymentRepository { get; }
    IConfigurationRepository ConfigurationRepository {  get; }
    IPaymentHistoryRepository PaymentHistoryRepository {  get; }
    ILogRepository LogRepository {  get; }
    IProcedureRepository ProcedureRepository {  get; }
    IProcedureGroupRepository ProcedureGroupRepository {  get; }
    IProcedureHealthPlanRepository ProcedureHealthPlanRepository {  get; }
    IRecordRespository RecordRespository {  get; }

    Task<int> SaveChangesAsync();
}
