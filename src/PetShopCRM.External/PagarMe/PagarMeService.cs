using PagarmeApiSDK.Standard;
using PagarmeApiSDK.Standard.Authentication;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.Infrastructure.Seetings;

namespace PetShopCRM.External.PagarMe;

public class PagarMeService : IPagarMeService
{
    private readonly IPagarmeApiSDKClient _client;

    public PagarMeService(AppSettings appSettings)
    {
        var auth = new BasicAuthModel.Builder(appSettings.PagarMe.User, appSettings.PagarMe.Password).Build();

        _client = new PagarmeApiSDKClient.Builder()
            .BasicAuthCredentials(auth)
            .ServiceRefererName("ServiceRefererName")
            .Build();
    }

    public void GerarCobrancaRecorrente(Guardian guardian)
    {
        var response = _client.SubscriptionsController.CreateSubscription(new PagarmeApiSDK.Standard.Models.CreateSubscriptionRequest
        {
            
        });
    }
}
