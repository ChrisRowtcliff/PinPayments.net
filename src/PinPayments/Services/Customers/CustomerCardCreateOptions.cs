namespace PinPayments.Services.Customers
{
    using System.Text.Json.Serialization;
    using PinPayments.Services.Cards;

    public class CustomerCardCreateOptions : CardCreateOptions
    {
        [JsonPropertyName("primary")]
        public bool Primary { get; set; }
    }
}