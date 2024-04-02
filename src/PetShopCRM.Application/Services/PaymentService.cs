using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class PaymentService(IUnitOfWork unitOfWork, IPagarMeService pagarMeService) : IPaymentService
{
    public async Task Generate(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null)
    {
        var guardian = await unitOfWork.GuardianRepository.GetByPetIdAsync(petId);
        var healthPan = await unitOfWork.HealthPlansRepository.GetByIdAsync(healthPlanId);

        if(guardian != null && healthPan != null)
        {
            var paymentResponse = pagarMeService.GenerateRecurrence(guardian, healthPan, card, billingAddress);

            if(paymentResponse != null && paymentResponse.Status.Equals("Success", StringComparison.OrdinalIgnoreCase))
            {
                var payment = new Payment
                {
                    ExternalId = paymentResponse.Id,
                    GuardianId = guardian.Id,
                    PetId = petId,
                    HealthPlanId = healthPan.Id,
                    IsRecurrence = true,
                    Installments = card.Installments,
                    LastPayment = DateTime.Now
                };

                await unitOfWork.PaymentRepository.AddOrUpdateAsync(payment);
                await unitOfWork.SaveChangesAsync();
            }
        }
    }
}
