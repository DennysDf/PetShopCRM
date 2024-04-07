using System.Text.Json.Serialization;

namespace PetShopCRM.Web.Models.Endereco;

public class AddressModel
{
    [JsonPropertyName("cep")]
    public string Cep { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("neighborhood")]
    public string Neighborhood { get; set; }

    [JsonPropertyName("street")]
    public string Street { get; set; }

    [JsonPropertyName("service")]
    public string Service { get; set; }
}
