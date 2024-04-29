using Microsoft.EntityFrameworkCore;
using PetShopCRM.Application.DTOs;
using PetShopCRM.Application.Services.Interfaces;
using PetShopCRM.Domain.Models;
using PetShopCRM.Infrastructure.Data.UnitOfWork.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopCRM.Application.Services;

public class PaymentHistoryService(IUnitOfWork unitOfWork) : IPaymentHistoryService
{
    public async Task<List<PaymentHistory>> GetAllAsync()
    {
        var paymentHistories = unitOfWork.PaymentHistoryRepository.GetBy(x => x.Active)
            .Include(x => x.Payment)
                .ThenInclude(x => x.HealthPlan)
            .Include(x => x.Payment)
                .ThenInclude(x => x.Pet)
            .Include(x => x.Payment)
                .ThenInclude(x => x.Guardian);

        return paymentHistories.ToList();
    }

    public bool ValidateEvent(string eventName)
    {
        var response = External.PagarMe.Resources.EventDescription.ResourceManager.GetString(eventName);

        return response != null;
    }

    public async Task<ResponseDTO<PaymentHistory?>> SaveAsync(string eventId, string eventName, decimal value)
    {
        var isSuccess = eventName.Equals("charge.paid");

        var signatureId = GetExternalIdByEventId(eventId);

        var payment = unitOfWork.PaymentRepository.GetBy(x => x.ExternalId == signatureId).FirstOrDefault();

        if (payment == null)
            return new ResponseDTO<PaymentHistory?>(false, Resources.Message.PaymentNotFound, null);

        var paymentHistory = new PaymentHistory
        {
            IsSuccess = isSuccess,
            PaymentId = payment.Id,
            Value = value,
            Event = ConvertEventToDescriptionResource(eventName)
        };

        await unitOfWork.PaymentHistoryRepository.AddOrUpdateAsync(paymentHistory);

        return new ResponseDTO<PaymentHistory?>(true, string.Empty, paymentHistory);
    }

    private string ConvertEventToDescriptionResource(string eventName)
    {
        return External.PagarMe.Resources.EventDescription.ResourceManager.GetString(eventName) ?? eventName;
    }

    private string GetExternalIdByEventId(string eventId)
    {
        return "";
    }
}
