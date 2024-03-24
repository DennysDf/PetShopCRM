namespace PetShopCRM.Domain.Models;

public  class Guardian : EntityBase
{
    public string Name { get; set; }
    public string DateBirth { get; set; }
    public string CPF { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    public virtual ICollection<Pet> Pets { get; set; }
}