namespace PinPayments.Services.WebhookEndpoints
{
    using System;
    using System.Text.Json.Serialization;

    internal class WebhookEndpointCreateOptions
    {
        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}