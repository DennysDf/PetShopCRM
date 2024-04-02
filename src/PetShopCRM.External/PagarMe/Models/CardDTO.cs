namespace PetShopCRM.External.PagarMe.Models;

public class CardDTO
{
    public string Number { get; set; }
    public string HolderName { get; set; }
    public int ExpirationMonth { get; set; }
    public int ExpirationYear { get; set; }
    public string Cvv { get; set; }
    public CardBrand Brand { get; set; }
    public int Installments { get; set; }
}