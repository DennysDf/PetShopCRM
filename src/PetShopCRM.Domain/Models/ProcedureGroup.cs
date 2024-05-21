namespace PetShopCRM.Domain.Models;

public class ProcedureGroup : EntityBase
{
    public string Description { get; set; }

    public virtual ICollection<Procedure> Procedures { get; set; }
}
