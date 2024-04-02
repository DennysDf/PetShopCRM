using Microsoft.Extensions.Options;
using PagarmeApiSDK.Standard;
using PagarmeApiSDK.Standard.Authentication;
using PagarmeApiSDK.Standard.Exceptions;
using PagarmeApiSDK.Standard.Models;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Infrastructure.Seetings;
using System.Drawing;

namespace PetShopCRM.External.PagarMe;

public class PagarMeService : IPagarMeService
{
    private readonly IPagarmeApiSDKClient _client;

    public PagarMeService(IOptions<AppSettings> appSettings)
    {
        var auth = new BasicAuthModel.Builder(appSettings.Value.PagarMe.User, appSettings.Value.PagarMe.Password).Build();

        _client = new PagarmeApiSDKClient.Builder()
            .BasicAuthCredentials(auth)
            .ServiceRefererName("ServiceRefererName")
            .Build();
    }

    public GetSubscriptionResponse? GenerateRecurrence(Guardian guardian, HealthPlan plan, CardDTO card, BillingAddressDTO? billingAddress = null)
    {
        var phone = guardian.Phone.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
        var planValue = plan.Value.ToString("#.00").Replace(".", "").Replace(",", "");

        try
        {
            var response = _client.SubscriptionsController.CreateSubscription(new CreateSubscriptionRequest
            {
                PaymentMethod = "credit_card",
                Currency = "BRL",
                Interval = "month",
                IntervalCount = 1,
                BillingType = "prepaid",
                Installments = 12,
                StatementDescriptor = plan.Name,
                Customer = new CreateCustomerRequest
                {
                    Name = guardian.Name,
                    Email = guardian.Email,
                    Document = guardian.CPF,
                    DocumentType = "CPF",
                    Type = "individual",
                    Phones = new CreatePhonesRequest
                    {
                        MobilePhone = new CreatePhoneRequest
                        {
                            CountryCode = "55",
                            AreaCode = phone[..2],
                            Number = phone[2..]
                        }
                    }
                },
                Card = new CreateCardRequest
                {
                    Number = card.Number,
                    HolderName = card.HolderName,
                    ExpMonth = card.ExpirationMonth,
                    ExpYear = card.ExpirationYear,
                    Cvv = card.Cvv,
                    Brand = card.Brand.ToString(),
                    BillingAddress = new CreateAddressRequest
                    {
                        Line1 = billingAddress?.Address ?? guardian.Address,
                        City = billingAddress?.City ?? guardian.City,
                        Country = billingAddress?.Country ?? guardian.Country,
                        State = billingAddress?.State ?? guardian.State,
                        ZipCode = billingAddress?.ZipCode ?? guardian.ZipCode,
                    }
                },
                Description = plan.Description,
                PricingScheme = new CreatePricingSchemeRequest
                {
                    SchemeType = "unit",
                    Price = int.Parse(planValue)
                },
                Quantity = 1
            });

            return response;
        }
        catch (ApiException ex)
        {

        }
        catch (Exception ex)
        {

            throw;
        }

        return null;
    }
}
