namespace PetShopCRM.Domain.Models;

public class ProcedureHealthPlan : EntityBase
{
    public decimal Coparticipation { get; set; }
    public int? AnnualLimit { get; set; }
    public int Lack { get; set; }
    public string Observation { get; set; }
    public int HealthPlanId { get; set; }
    public int ProcedureId { get; set; }
    
    public virtual HealthPlan HealthPlan { get; set; }
    public virtual Procedure Procedure { get; set; }
}