using PagarmeApiSDK.Standard.Models;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;

namespace PetShopCRM.External.PagarMe.Interfaces;

public interface IPagarMeService
{
    GetSubscriptionResponse? GenerateRecurrence(Guardian guardian, HealthPlan plan, CardDTO card, BillingAddressDTO? billingAddress = null);
    GetSubscriptionResponse? CancelSubscription(string subscriptionId);
    GetBalanceResponse? GetAvailableValues();
    GetSubscriptionResponse? RenewRecurrence(HealthPlan plan, string customerId, string cardId, string value);
}
