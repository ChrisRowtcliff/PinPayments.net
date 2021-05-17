namespace PinPayments.Entities.Subscriptions
{
    using System;
    using System.Text.Json.Serialization;

    public class Ledger
    {
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("annotation")]
        public string Annotation { get; set; }
    }
}