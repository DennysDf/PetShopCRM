using PagarmeApiSDK.Standard.Models;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;

namespace PetShopCRM.External.PagarMe.Interfaces;

public interface IPagarMeService
{
    GetSubscriptionResponse? GenerateRecurrence(Guardian guardian, HealthPlan plan, CardDTO card, BillingAddressDTO? billingAddress = null);
    GetSubscriptionResponse? CancelSubscription(string subscriptionId);
    ListPayablesResponse GetPayables(string? type = null, string? status = null, int? page = null, int? size = null);
    GetSubscriptionResponse? RenewRecurrence(HealthPlan plan, string customerId, string cardId, string value);
}
