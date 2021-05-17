namespace PinPayments.Entities.Refunds
{
    using System;
    using System.Text.Json.Serialization;

    public class Refund : IEvent
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("charge")]
        public string Charge { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("status_message")]
        public string StatusMessage { get; set; }
    }
}