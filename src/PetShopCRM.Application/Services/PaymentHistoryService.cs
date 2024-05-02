using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services;

public class PaymentHistoryService(IUnitOfWork unitOfWork) : IPaymentHistoryService
{
    public async Task<List<PaymentHistory>> GetAllAsync(int? paymentId = null)
    {
        var paymentHistories = unitOfWork.PaymentHistoryRepository.GetBy()
            .Include(x => x.Payment)
                .ThenInclude(x => x.HealthPlan)
            .Include(x => x.Payment)
                .ThenInclude(x => x.Pet)
            .Include(x => x.Payment)
                .ThenInclude(x => x.Guardian)
             .AsQueryable();

        if(paymentId.HasValue)
            paymentHistories = paymentHistories.Where(x => x.PaymentId ==  paymentId.Value);

        return paymentHistories.OrderByDescending(x => x.CreatedDate).ToList();
    }

    public async  Task<ResponseDTO<List<PaymentHistory>>> GetAllCompleteAsync()
    {
        var paymentHistory = unitOfWork.PaymentHistoryRepository.GetBy();

        var result = paymentHistory
            .Include(c => c.Payment)
                .ThenInclude(c => c.HealthPlan)
            .ToList();

        return new ResponseDTO<List<PaymentHistory>>(result.Count > 0, "Nenhum resultado encontrado", result);
    }

    public bool ValidateEvent(string eventName)
    {
        var response = External.PagarMe.Resources.EventDescription.ResourceManager.GetString(eventName);

        return response != null;
    }

    public async Task<ResponseDTO<PaymentHistory?>> SaveAsync(string eventName, JsonElement data)
    {
        var isSuccess = eventName.Equals("charge.paid");

        var signatureId = GetSubscriptionId(eventName, data);
        var value = GetValue(eventName, data);

        _ = decimal.TryParse(value[..^2] + "," + value[^2..], NumberStyles.Currency, CultureInfo.GetCultureInfo("pt-BR"), out decimal parsedValue);

        var payment = unitOfWork.PaymentRepository.GetBy(x => x.ExternalId == signatureId).FirstOrDefault();

        if (payment == null)
            return new ResponseDTO<PaymentHistory?>(false, Resources.Message.PaymentNotFound, null);

        var paymentHistory = new PaymentHistory
        {
            ExternalId = signatureId,
            IsSuccess = isSuccess,
            PaymentId = payment.Id,
            Value = parsedValue,
            Event = ConvertEventToDescriptionResource(eventName)
        };

        await unitOfWork.PaymentHistoryRepository.AddOrUpdateAsync(paymentHistory);
        await unitOfWork.SaveChangesAsync();

        return new ResponseDTO<PaymentHistory?>(true, string.Empty, paymentHistory);
    }

    private string ConvertEventToDescriptionResource(string eventName)
    {
        return External.PagarMe.Resources.EventDescription.ResourceManager.GetString(eventName) ?? eventName;
    }

    private string GetSubscriptionId(string eventName, JsonElement data)
    {
        var subscriptionId = eventName switch
        {
            "charge.antifraud_reproved" => data.GetProperty("invoice").GetProperty("subscriptionId").GetString(),
            "charge.paid" => data.GetProperty("invoice").GetProperty("subscriptionId").GetString(),
            "charge.payment_failed" => data.GetProperty("invoice").GetProperty("subscriptionId").GetString(),
            "charge.refunded" => data.GetProperty("invoice").GetProperty("subscriptionId").GetString(),
            "subscription.canceled" => data.GetProperty("id").GetString(),
            "subscription.created" => data.GetProperty("id").GetString(),
            _ => data.GetProperty("invoice").GetProperty("subscriptionId").GetString()
        } ?? "";

        return subscriptionId;
    }

    private string GetValue(string eventName, JsonElement data)
    {
        var value = eventName switch
        {
            "charge.antifraud_reproved" => data.GetProperty("amount").GetInt32(),
            "charge.paid" => data.GetProperty("paid_amount").GetInt32(),
            "charge.payment_failed" => data.GetProperty("amount").GetInt32(),
            "charge.refunded" => data.GetProperty("amount").GetInt32(),
            "subscription.canceled" => data.GetProperty("items")[0].GetProperty("pricing_scheme").GetProperty("price").GetInt32(),
            "subscription.created" => data.GetProperty("items")[0].GetProperty("pricing_scheme").GetProperty("price").GetInt32(),
            _ => data.GetProperty("amount").GetInt32()
        };

        return value.ToString("0000");
    }
}
