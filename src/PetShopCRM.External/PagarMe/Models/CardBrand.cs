using System.ComponentModel;

namespace PetShopCRM.External.PagarMe.Models;

public enum CardBrand
{
    [Description("Visa")]
    visa,
    [Description("Mastercard")]
    mastercard,
    [Description("Hipercard")]
    hipercard,
    [Description("Elo")]
    elo,
    [Description("Credz")]
    credz,
    [Description("Sorocred")]
    sorocred,
    [Description("Banescard")]
    banescard
}
