using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using PetShopCRM.External.PagarMe.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPaymentService
{
    Task<List<Payment>> GetAllAsync();
    Task<ResponseDTO<Payment?>> GenerateAsync(int petId, int healthPlanId, CardDTO card, BillingAddressDTO? billingAddress = null);
}
