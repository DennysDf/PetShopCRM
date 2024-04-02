using PetShopCRM.External.PagarMe.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPaymentService
{
    public Task Generate(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null);
}
