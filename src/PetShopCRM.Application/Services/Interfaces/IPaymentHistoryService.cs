using PetShopCRM.Application.DTOs;
using PetShopCRM.Domain.Models;
using System.Text.Json;

namespace PetShopCRM.Application.Services.Interfaces;

public interface IPaymentHistoryService
{
    Task<List<PaymentHistory>> GetAllAsync(int? paymentId = null);
    bool ValidateEvent(string eventName);
    Task<ResponseDTO<PaymentHistory?>> SaveAsync(string eventName, JsonElement data);
}
