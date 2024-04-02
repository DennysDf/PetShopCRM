using Microsoft.Extensions.DependencyInjection;
using PetShopCRM.External.PagarMe;
using PetShopCRM.External.PagarMe.Interfaces;

namespace PetShopCRM.External;

public static class Bootstrapper
{
    public static IServiceCollection AddExternalServices(this IServiceCollection services)
    {
        services.AddSingleton<IPagarMeService, PagarMeService>();

        return services;
    }
}
