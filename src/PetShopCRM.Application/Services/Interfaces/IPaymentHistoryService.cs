using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPaymentHistoryService
{
    Task<List<PaymentHistory>> GetAllAsync();
    bool ValidateEvent(string eventName);
    Task<ResponseDTO<PaymentHistory?>> SaveAsync(string eventId, string eventName, decimal value);
}
