namespace PetShopCRM.Domain.Models;

public class Specie : EntityBase
{
    public string Name { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }
}
