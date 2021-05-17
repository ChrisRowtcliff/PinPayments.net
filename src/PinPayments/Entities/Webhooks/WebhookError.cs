namespace PinPayments.Entities.Webhooks
{
    using System.Text.Json.Serialization;

    public class WebhookError
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }
    }
}