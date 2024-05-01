using Microsoft.EntityFrameworkCore;
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
        var payments = unitOfWork.PaymentRepository.GetBy().ToList();

        return payments;
    }

    public async Task<ResponseDTO<List<Payment>>> GetAllCompleteAsync()
    {
        var payments = unitOfWork.PaymentRepository.GetBy();

        var result = payments
            .Include(x => x.Guardian)
            .Include(x => x.Pet)
            .Include(x => x.HealthPlan)
            .ToList();

        return new ResponseDTO<List<Payment>>(result.Count > 0, "Nenhum resultado encontrado", result);
    }

    public async Task<ResponseDTO<Payment?>> GenerateAsync(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null)
    {
        try
        {
            var guardian = await unitOfWork.GuardianRepository.GetByPetIdAsync(petId);
            var healthPan = await unitOfWork.HealthPlansRepository.GetByIdAsync(healthPlanId);

            var paymentResponse = pagarMeService.GenerateRecurrence(guardian, healthPan, card, billingAddress);

            if (paymentResponse != null)
            {
                var payment = new Payment
                {
                    ExternalId = paymentResponse.Id,
                    GuardianId = guardian.Id,
                    PetId = petId,
                    HealthPlanId = healthPan.Id,
                    IsRecurrence = true,
                    Installment = 0,
                    FirstPayment = DateTime.Now,
                    LastPayment = DateTime.Now,
                    IsSuccess = paymentResponse.Status.Equals("active", StringComparison.OrdinalIgnoreCase)
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

    public string GenerateWebhookUrl(string host)
    {
        return new Uri(new Uri(host), "/Payment/Webhook").AbsoluteUri;
    }

    public async Task UpdateLastPaymentDateAndInstallmentAsync(int id, DateTime date)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(id);

        if(payment != null)
        {
            payment.LastPayment = date;
            payment.Installment++;

            await unitOfWork.PaymentRepository.AddOrUpdateAsync(payment);
            await unitOfWork.SaveChangesAsync();
        }
    }

    public async Task<bool> CancelAsync(int id)
    {
        var payment = await unitOfWork.PaymentRepository.GetByIdAsync(id);

        if (payment == null) return false;

        var result = pagarMeService.CancelSubscription(payment.ExternalId);

        var deleted = await unitOfWork.PaymentRepository.DeleteOrRestoreAsync(payment.Id);
        await unitOfWork.SaveChangesAsync();

        return result != null && deleted;
    }
}
