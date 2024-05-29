using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Payments;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPaymentService
{
    Payment? GetById(int id);
    Task<List<Payment>> GetAllAsync();
    Task<ResponseDTO<Payment?>> AddOrUpdateAsync(int petId, int healthPlanId, int? paymentId = null, CardDTO? card = null, BillingAddressDTO? billingAddress = null, CustomerDTO? customer = null);
    string GenerateWebhookUrl();
    Task<ResponseDTO<List<Payment>>> GetAllCompleteAsync(int idPet = 0);
    Task UpdateLastPaymentDateAndInstallmentAsync(int id, DateTime date);
    Task<bool> DeleteAsync(int id);
    Task<bool> CancelAsync(int id);
    decimal GetValue();
    PlanDateCreateDTO GetPlanByPet(int id);
}
