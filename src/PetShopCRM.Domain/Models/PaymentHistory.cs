namespace PetShopCRM.Domain.Models;

public class PaymentHistory : EntityBase
{
    public int PaymentId { get; set; }
    public bool IsSuccess { get; set; }
    public string Event { get; set; }
    public decimal Value { get; set; }
    
    public virtual Payment Payment { get; set; }
}
