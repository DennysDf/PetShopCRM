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

        return services;
    }
}
