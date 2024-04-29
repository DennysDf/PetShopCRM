namespace PetShopCRM.Domain.Models;

public class Payment : EntityBase
{
    public string ExternalId { get; set; }
    public int PetId { get; set; }
    public int GuardianId { get; set; }
    public int HealthPlanId { get; set; }
    public bool IsRecurrence { get; set; }
    public int Installment { get; set;}
    public DateTime? FirstPayment { get; set; }
    public DateTime? LastPayment { get; set; }

    public virtual Pet Pet { get; set; }
    public virtual Guardian Guardian { get; set; }
    public virtual HealthPlan HealthPlan { get; set; }

    public virtual ICollection<PaymentHistory> PaymentHistories { get; set; }
}
