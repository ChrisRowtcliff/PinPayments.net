namespace PinPayments.Entities.WebhookEndpoints
{
    using System;
    using System.Text.Json.Serialization;

    public class WebhookEndpoint
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}