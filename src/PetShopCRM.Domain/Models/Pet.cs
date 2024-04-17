namespace PetShopCRM.Domain.Models;

public class Pet : EntityBase
{
    public string Name { get; set; }
    public int GuardianId { get; set; }
    public string Identifier { get; set; }
    public int SpecieId { get; set; }

    public virtual Guardian Guardian { get; set; }
    public virtual Specie Specie { get; set; }
}
