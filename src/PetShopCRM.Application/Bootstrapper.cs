using Microsoft.Extensions.DependencyInjection;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Application;

public static class Bootstrapper
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IGuardianService, GuardianService>();
        services.AddScoped<IClinicService, ClinicService>();
        services.AddScoped<IPetService, PetService>();
        services.AddScoped<ISpecieService, SpecieService>();
        services.AddScoped<IHealthPlanService, HealthPlanService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IConfigurationService, ConfigurationService>();
        services.AddScoped<IPaymentHistoryService, PaymentHistoryService>();
        services.AddScoped<ILogService, LogService>();
        services.AddScoped<IProcedureService, ProcedureService>();
        services.AddScoped<IProcedureGroupService, ProcedureGroupService>();
        services.AddScoped<IEmailService, EmailService>();

        return services;
    }
}
