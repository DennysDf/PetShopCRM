using Microsoft.Extensions.DependencyInjection;
using PetShopCRM.Infrastructure.Data;
using PetShopCRM.Infrastructure.Data.Interfaces;

namespace PetShopCRM.Infrastructure;

public static class Boostrapper
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFakeRepository, FakeRepository>();

        return services;
    }
}
