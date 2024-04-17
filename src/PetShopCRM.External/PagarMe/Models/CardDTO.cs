namespace PetShopCRM.External.PagarMe.Models;

public record CardDTO(string Number, string HolderName, int ExpirationMonth, int ExpirationYear, string Cvv, CardBrand Brand, int Installments);