namespace PinPayments.Services.Customers
{
    using System.Text.Json.Serialization;

    public class CustomerUpdateOptions : CustomerCreateOptions
    {
        [JsonPropertyName("primary_card_token")]
        public string PrimaryCardToken { get; set; }
    }
}