namespace PetShopCRM.External.PagarMe.Models;

public record CardDTO(string Number, string HolderName, string ExpirationMonth, string ExpirationYear, string Cvv, CardBrand Brand);