using Newtonsoft.Json.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PetShopCRM.External.PagarMe.Models;

public record WebhookDTO
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("account")]
    public WebhookAccount Account { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; }

    [JsonPropertyName("created_at")]
    public string CreatedAt { get; init; }

    [JsonPropertyName("data")]
    public JsonElement Data { get; init; }
}

public record WebhookAccount
{
    [JsonPropertyName("id")]
    public string Id { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; }
}