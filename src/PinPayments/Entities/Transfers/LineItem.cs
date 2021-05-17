namespace PinPayments.Entities.Transfers
{
    using System;
    using System.Text.Json.Serialization;

    public class LineItem
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("record")]
        public Record Record { get; set; }
    }
}