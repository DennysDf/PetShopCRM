namespace PetShopCRM.Domain.Models;

public  class Guardian : EntityBase
{
    public string Name { get; set; }
    public string DateBirth { get; set; }
    public string CPF { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string CEP { get; set; }
    public string Neighborhood { get; set; }
    public string Unit { get; set; }
    public string Number { get; set; }


    public virtual ICollection<Pet> Pets { get; set; }
    public virtual ICollection<Payment> Payments { get; set; }
}