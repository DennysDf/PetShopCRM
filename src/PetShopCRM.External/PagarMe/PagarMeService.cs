using PagarmeApiSDK.Standard;
using PagarmeApiSDK.Standard.Authentication;
using PagarmeApiSDK.Standard.Exceptions;
using PagarmeApiSDK.Standard.Models;
using PetShopCRM.Domain.Enums;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.External.PagarMe;

public class PagarMeService : IPagarMeService
{
    private readonly IPagarmeApiSDKClient _client;

    public PagarMeService(IUnitOfWork unitOfWork)
    {
        var pagarMeUser = unitOfWork.ConfigurationRepository.GetBy(x => x.Key == ConfigurationKey.PagarMeUser).FirstOrDefault()?.Value ?? "";
        var pagarMePassword = unitOfWork.ConfigurationRepository.GetBy(x => x.Key == ConfigurationKey.PagarMePassword).FirstOrDefault()?.Value ?? "";

        var auth = new BasicAuthModel.Builder(pagarMeUser, pagarMePassword).Build();

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
                    Email = guardian.Email ?? "teste@gmail.com",
                    Document = guardian.CPF.Replace(".", "").Replace("-", ""),
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
                    Number = card.Number.Replace(" ", ""),
                    HolderName = card.HolderName,
                    ExpMonth = int.Parse(card.ExpirationMonth),
                    ExpYear = int.Parse(card.ExpirationYear),
                    Cvv = card.Cvv,
                    Brand = card.Brand.ToString(),
                    BillingAddress = new CreateAddressRequest
                    {
                        Line1 = billingAddress?.Address ?? guardian.Address,
                        City = billingAddress?.City ?? guardian.City,
                        Country = billingAddress?.Country ?? guardian.Country,
                        State = billingAddress?.State ?? guardian.State,
                        ZipCode = billingAddress?.ZipCode ?? guardian.CEP,
                    }
                },
                Description = plan.Description ?? plan.Name,
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

    public GetSubscriptionResponse? CancelSubscription(string subscriptionId)
    {
        return _client.SubscriptionsController.CancelSubscription(subscriptionId, new CreateCancelSubscriptionRequest
        {
            CancelPendingInvoices = true
        });
    }

    //status: paid ou waiting_funds
    //type: chargeback, refund, chargeback_refund ou credit
    public ListPayablesResponse GetPayables(string? type = null, string? status = null, int? page = null, int? size = null)
    {
        return _client.PayablesController.GetPayables(type: type, status: status, page: page, size: size);
    }
}
