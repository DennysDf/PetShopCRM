namespace PetShopCRM.Domain.Models;

public class HealthPlan : EntityBase
{
    public string Name { get; set; }
    public decimal Value { get; set; }
    public string Description { get; set; }

    public virtual ICollection<Payment> Payments { get; set; }
    public virtual ICollection<ProcedureHealthPlan> ProcedureHealthPlans { get; set; }
}
