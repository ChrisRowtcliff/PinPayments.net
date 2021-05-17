namespace PinPayments.Services.Subscriptions
{
    using System.Text.Json.Serialization;

    internal class SubscriptionUpdateOptions
    {
        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }
    }
}