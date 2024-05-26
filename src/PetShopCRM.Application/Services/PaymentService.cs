using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Payments;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Interfaces;
using PetShopCRM.External.PagarMe.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System.Globalization;
using System.Text.Json;

namespace PetShopCRM.Application.Services;

public class PaymentService(IUnitOfWork unitOfWork, IPagarMeService pagarMeService) : IPaymentService
{
    public Payment? GetById(int id)
    {
        return unitOfWork.PaymentRepository.GetBy(x => x.Id == id)
            .Include(x => x.HealthPlan)
            .FirstOrDefault();
    }

    public async Task<List<Payment>> GetAllAsync()
    {
        var payments = unitOfWork.PaymentRepository.GetBy().ToList();

        return payments;
    }

    public async Task<ResponseDTO<List<Payment>>> GetAllCompleteAsync(int idPet = 0)
    {
        var payments = unitOfWork.PaymentRepository.GetBy()
            .Include(x => x.Guardian)
            .Include(x => x.Pet)
                .ThenInclude(x => x.Specie)
            .Include(x => x.HealthPlan)    
            .Where(c => c.IsSuccess)
            .AsQueryable(); 

        if (idPet != 0)
            payments = payments.Where(c => c.PetId == idPet);

        return new ResponseDTO<List<Payment>>(payments.ToList().Count > 0, "Nenhum resultado encontrado", payments.ToList());
    }

    public async Task<ResponseDTO<Payment?>> GenerateAsync(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null, CustomerDTO? customer = null)
    {
        try
        {
            var guardian = await unitOfWork.GuardianRepository.GetByPetIdAsync(petId);
            var healthPan = await unitOfWork.HealthPlansRepository.GetByIdAsync(healthPlanId);

            var paymentResponse = pagarMeService.GenerateRecurrence(guardian, healthPan, card, billingAddress, customer);

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

        //var result = pagarMeService.CancelSubscription(payment.ExternalId);

        var deleted = await unitOfWork.PaymentRepository.DeleteOrRestoreAsync(payment.Id);
        await unitOfWork.SaveChangesAsync();

        return true != null && deleted;
    }

    public decimal GetValue()
    {
        var response = pagarMeService.GetAvailableValues();

        var value = response?.AvailableAmount?.ToString("0000") ?? "0000";

        _ = decimal.TryParse(value[..^2] + "," + value[^2..], NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out decimal parsedValue);
        return parsedValue;
    } 

    public PlanDateCreateDTO GetPlanByPet(int id)
    {
        var payments = unitOfWork.PaymentRepository.GetBy();
        var planDateCreateDTO = payments.Where(c => c.PetId == id && c.IsSuccess && c.Active).Select(c => new PlanDateCreateDTO(c.HealthPlanId, c.CreatedDate)).First();

        return planDateCreateDTO;
    }
}
