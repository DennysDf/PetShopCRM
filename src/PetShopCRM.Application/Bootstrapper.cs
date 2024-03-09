using Microsoft.Extensions.DependencyInjection;
using PetShopCRM.Application.Services;
using PetShopCRM.Application.Services.Interfaces;

namespace PetShopCRM.Application;

public static class Bootstrapper
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IFakeService, FakeService>();

        return services;
    }
}
