using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.DTOs.Payments;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;
using System.Text.Json;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPaymentService
{
    Payment? GetById(int id);
    Task<List<Payment>> GetAllAsync();
    Task<ResponseDTO<Payment?>> GenerateAsync(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null, CustomerDTO? customer = null);
    string GenerateWebhookUrl(string host);
    Task<ResponseDTO<List<Payment>>> GetAllCompleteAsync(int idPet = 0);
    Task UpdateLastPaymentDateAndInstallmentAsync(int id, DateTime date);
    Task<bool> CancelAsync(int id);
    decimal GetValue();
    PlanDateCreateDTO GetPlanByPet(int id);
}
