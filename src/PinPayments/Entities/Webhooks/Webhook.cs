namespace PinPayments.Entities.Webhooks
{
    using PinPayments.Json;
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class Webhook
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("event_token")]
        public string EventToken { get; set; }

        [JsonPropertyName("webhook_endpoint_token")]
        public string WebhookEndpointToken { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("accepted_at")]
        public DateTime? AcceptedAt { get; set; }

        [JsonPropertyName("next_run")]
        public DateTime? NextRun { get; set; }

        [JsonPropertyName("retries")]
        public int Retries { get; set; }

        [JsonPropertyName("errors"), JsonConverter(typeof(WebhookErrorSerialiser))]
        public Dictionary<DateTime, WebhookError> Errors { get; set; }
    }
}