using System.Text.Json.Serialization;

namespace PetShopCRM.External.PagarMe.Models;

public record WebhookDTO(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("account")] WebhookAccount account,
    [property: JsonPropertyName("type")] string type,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("data")] WebhookData data
);

public record WebhookAccount(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("name")] string name
);

public record WebhookAddress(
    [property: JsonPropertyName("zip_code")] string zip_code,
    [property: JsonPropertyName("city")] string city,
    [property: JsonPropertyName("state")] string state,
    [property: JsonPropertyName("country")] string country,
    [property: JsonPropertyName("line_1")] string line_1
);

public record WebhookBillingAddress(
    [property: JsonPropertyName("zip_code")] string zip_code,
    [property: JsonPropertyName("city")] string city,
    [property: JsonPropertyName("state")] string state,
    [property: JsonPropertyName("country")] string country,
    [property: JsonPropertyName("line_1")] string line_1
);

public record WebhookCard(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("last_four_digits")] string last_four_digits,
    [property: JsonPropertyName("brand")] string brand,
    [property: JsonPropertyName("holder_name")] string holder_name,
    [property: JsonPropertyName("exp_month")] int exp_month,
    [property: JsonPropertyName("exp_year")] int exp_year,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("updated_at")] DateTime updated_at,
    [property: JsonPropertyName("billing_address")] WebhookBillingAddress billing_address,
    [property: JsonPropertyName("type")] string type
);

public record WebhookCharge(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("code")] string code,
    [property: JsonPropertyName("gateway_id")] string gateway_id,
    [property: JsonPropertyName("amount")] int amount,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("currency")] string currency,
    [property: JsonPropertyName("payment_method")] string payment_method,
    [property: JsonPropertyName("paid_at")] DateTime paid_at,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("updated_at")] DateTime updated_at,
    [property: JsonPropertyName("customer")] WebhookCustomer customer,
    [property: JsonPropertyName("last_transaction")] WebhookLastTransaction last_transaction
);

public record WebhookCustomer(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("name")] string name,
    [property: JsonPropertyName("email")] string email,
    [property: JsonPropertyName("document")] string document,
    [property: JsonPropertyName("type")] string type,
    [property: JsonPropertyName("delinquent")] bool delinquent,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("updated_at")] DateTime updated_at,
    [property: JsonPropertyName("phones")] WebhookPhones phones
);

public record WebhookData(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("code")] string code,
    [property: JsonPropertyName("amount")] int amount,
    [property: JsonPropertyName("currency")] string currency,
    [property: JsonPropertyName("closed")] bool closed,
    [property: JsonPropertyName("items")] IReadOnlyList<WebhookItem> items,
    [property: JsonPropertyName("customer")] WebhookCustomer customer,
    [property: JsonPropertyName("shipping")] WebhookShipping shipping,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("updated_at")] DateTime updated_at,
    [property: JsonPropertyName("closed_at")] DateTime closed_at,
    [property: JsonPropertyName("charges")] IReadOnlyList<WebhookCharge> charges
);

public record WebhookGatewayResponse(
    [property: JsonPropertyName("code")] string code
);

public record WebhookItem(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("description")] string description,
    [property: JsonPropertyName("amount")] int amount,
    [property: JsonPropertyName("quantity")] int quantity,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("updated_at")] DateTime updated_at
);

public record WebhookLastTransaction(
    [property: JsonPropertyName("id")] string id,
    [property: JsonPropertyName("transaction_type")] string transaction_type,
    [property: JsonPropertyName("gateway_id")] string gateway_id,
    [property: JsonPropertyName("amount")] int amount,
    [property: JsonPropertyName("status")] string status,
    [property: JsonPropertyName("success")] bool success,
    [property: JsonPropertyName("installments")] int installments,
    [property: JsonPropertyName("acquirer_name")] string acquirer_name,
    [property: JsonPropertyName("acquirer_affiliation_code")] string acquirer_affiliation_code,
    [property: JsonPropertyName("acquirer_tid")] string acquirer_tid,
    [property: JsonPropertyName("acquirer_nsu")] string acquirer_nsu,
    [property: JsonPropertyName("acquirer_auth_code")] string acquirer_auth_code,
    [property: JsonPropertyName("operation_type")] string operation_type,
    [property: JsonPropertyName("card")] WebhookCard card,
    [property: JsonPropertyName("created_at")] DateTime created_at,
    [property: JsonPropertyName("updated_at")] DateTime updated_at,
    [property: JsonPropertyName("gateway_response")] WebhookGatewayResponse gateway_response
);

public record WebhookPhones(

);

public record WebhookShipping(
    [property: JsonPropertyName("amount")] int amount,
    [property: JsonPropertyName("description")] string description,
    [property: JsonPropertyName("address")] WebhookAddress address
);

