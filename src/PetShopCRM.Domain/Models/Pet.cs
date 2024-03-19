namespace PetShopCRM.Domain.Models;

public class Pet : EntityBase
{
    public string Name { get; set; }
    public int GuardianId { get; set; }
    public Guardian Guardian { get; set; }
    public string Identifier { get; set; }
    public int EspecieId { get; set; }
}
