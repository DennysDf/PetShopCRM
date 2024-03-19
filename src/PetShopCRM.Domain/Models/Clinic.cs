namespace PetShopCRM.Domain.Models;

public class Clinic : EntityBase
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Phone { get; set; }
    public string Responsible { get; set; }
    public string CNPJ { get; set; }
}
