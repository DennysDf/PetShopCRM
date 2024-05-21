namespace PetShopCRM.Domain.Models;

public  class Procedure : EntityBase
{   
    public string Description { get; set; }
    public int ProcedureGroupId { get; set; }

    public virtual ProcedureGroup ProcedureGroup { get; set; }
    public virtual ICollection<ProcedureHealthPlan> ProcedureHealthPlans { get; set; }

}
