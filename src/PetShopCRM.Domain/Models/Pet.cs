namespace PetShopCRM.Domain.Models;

public class Pet : EntityBase
{
    public string Nome { get; set; }
    public int TutorId { get; set; }
    public string Identificador { get; set; }
    public int EspecieId { get; set; }
}
