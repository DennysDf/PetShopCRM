using PetShopCRM.Web.Util;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using PetShopCRM.Domain.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

public class PaymentsListsVM()
{
    public string Name { get; set; }
    public string Identifier { get; set; }
    public string Specie { get; set; }
    public string Guardian { get; set; }

    public List<PaymentsVM> ListPayments { get; set; }
    public List<PaymentsHistoryVM> ListPaymentsHistories { get; set; }

    public PaymentsListsVM GetPayments(List<PetShopCRM.Domain.Models.Payment?> payments, List<PaymentHistory?> paymentHistories, Pet pet)
    {
        var name = pet.Name;
        var identifier = pet.Identifier;
        var specie = pet.Specie.Name;
        var guardian = pet.Guardian.Name;

        this.ListPayments = payments.Select(c => new PaymentsVM { Id = c.Id.ToString() , Installment = c.Installment.ToString(), Value = c.HealthPlan.Value, Name = c.HealthPlan.Name, IsSuccess = c.IsSuccess, IsActive = c.Active  }).ToList();

        return new PaymentsListsVM() { Name = name, Specie = specie, Identifier = identifier, Guardian = guardian, ListPayments = ListPayments, };
    }
}

public class PaymentsVM()
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Installment { get; set; }
    public bool IsSuccess { get; set; }
    public bool IsActive { get; set; }

}

public class PaymentsHistoryVM()
{
    public string PaymentId { get; set; }
    public string Event { get; set; }
    public decimal Value { get; set; }
    public string Date { get; set; }

}
