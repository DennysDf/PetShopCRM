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

    public GetSubscriptionResponse? GenerateRecurrence(Guardian guardian, HealthPlan plan, CardDTO card, BillingAddressDTO? billingAddress = null, CustomerDTO? customer = null)
    {
        var phone = (customer?.Phone ?? guardian.Phone).Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "").Trim();
        var planValue = plan.Value.ToString("#.00").Replace(".", "").Replace(",", "");
        var address = billingAddress != null ? $"{billingAddress.Number}, {billingAddress.Address}, {billingAddress.Neighborhood}" : $"{guardian.Number}, {guardian.Address}, {guardian.Neighborhood}";
        try
        {
            var response = _client.SubscriptionsController.CreateSubscription(new CreateSubscriptionRequest
            {
                PaymentMethod = "credit_card",
                Currency = "BRL",
                Interval = "month",
                IntervalCount = 1,
                BillingType = "prepaid",
                StatementDescriptor = plan.Name.Contains('-') ? plan.Name.Split("-")[1] : plan.Name,
                Customer = new CreateCustomerRequest
                {
                    Name = customer?.Name ?? guardian.Name,
                    Email = customer?.Email ?? guardian.Email,
                    Document = (customer?.CPF ?? guardian.CPF).Replace(".", "").Replace("-", ""),
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
                        Line1 = address,
                        Line2 = billingAddress?.Unit ?? guardian.Unit,
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
        catch (ApiException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public GetSubscriptionResponse? CancelSubscription(string subscriptionId)
    {
        return _client.SubscriptionsController.CancelSubscription(subscriptionId, new CreateCancelSubscriptionRequest
        {
            CancelPendingInvoices = true
        });
    }

    public GetBalanceResponse? GetAvailableValues()
    {
        var recipients = _client.RecipientsController.GetRecipients();

        if (recipients.Data.Count != 0)
        {
            var balance = _client.RecipientsController.GetBalance(recipients.Data.First().Id);

            return balance;
        }

        return null;
    }

    public GetSubscriptionResponse? RenewRecurrence(HealthPlan plan, string customerId, string cardId, string value)
    {
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
                Quantity = 1,
                StartAt = DateTime.Now.AddDays(30),
                StatementDescriptor = plan.Name,
                Description = plan.Description ?? plan.Name,
                CustomerId = customerId,
                CardId = cardId,
                PricingScheme = new CreatePricingSchemeRequest
                {
                    SchemeType = "unit",
                    Price = int.Parse(value)
                },
            });

            return response;
        }
        catch (ApiException)
        {
            throw;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
