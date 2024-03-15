namespace PetShopCRM.Domain.Models;

public class EntityBase
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool Ativo { get; set; }
}
