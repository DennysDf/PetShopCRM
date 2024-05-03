using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Domain.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

public class PaymentsListsVM()
{
    public List<PaymentsVM> ListPayments { get; set; }
    public List<PaymentsHistoryVM> ListPaymentsHistories { get; set; }

    public PaymentsListsVM GetPayments(List<PetShopCRM.Domain.Models.Payment?> payments, List<PaymentHistory?> paymentHistories)
    {
        this.ListPayments = payments.Select(c => new PaymentsVM { Id = c.ExternalId, Installment = c.Installment.ToString(), Value = c.HealthPlan.Value, Name = c.HealthPlan.Name }).ToList();

        this.ListPaymentsHistories = paymentHistories.Select(c => new PaymentsHistoryVM { PaymentId = c.ExternalId, Date = c.CreatedDate.ToString(), Event = c.Event, Value = c.Value }).ToList();

        return new PaymentsListsVM() { ListPayments = ListPayments, ListPaymentsHistories = ListPaymentsHistories };
    }
}

public class PaymentsVM()
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Installment { get; set; }

}

public class PaymentsHistoryVM()
{
    public string PaymentId { get; set; }
    public string Event { get; set; }
    public decimal Value { get; set; }
    public string Date { get; set; }

}
