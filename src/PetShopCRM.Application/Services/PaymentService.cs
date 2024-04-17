using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;

namespace PetShopCRM.Application.Services;

public class PaymentService(IUnitOfWork unitOfWork, IPagarMeService pagarMeService) : IPaymentService
{
    public async Task<List<Payment>> GetAllAsync()
    {
        var guardians = await unitOfWork.PaymentRepository.GetByAsync();

        return guardians.ToList();
    }

    public async Task<ResponseDTO<Payment?>> GenerateAsync(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null)
    {
        try
        {
            var guardian = await unitOfWork.GuardianRepository.GetByPetIdAsync(petId);
            var healthPan = await unitOfWork.HealthPlansRepository.GetByIdAsync(healthPlanId);

            var paymentResponse = pagarMeService.GenerateRecurrence(guardian, healthPan, card, billingAddress);

            if (paymentResponse != null && paymentResponse.Status.Equals("Success", StringComparison.OrdinalIgnoreCase))
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

                return new ResponseDTO<Payment?>(true, string.Empty, payment);
            }

            return new ResponseDTO<Payment?>(false, Resources.Message.PaymentIntegrationFailed, null);
        }
        catch (Exception ex)
        {
            return new ResponseDTO<Payment?>(false, ex.Message, null);
        }
    }
}
