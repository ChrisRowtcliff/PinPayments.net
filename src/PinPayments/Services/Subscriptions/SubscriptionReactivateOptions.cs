namespace PinPayments.Services.Subscriptions
{
    using System.Text.Json.Serialization;

    internal class SubscriptionReactivateOptions
    {
        [JsonPropertyName("include_setup_fee")]
        public bool IncludeSetupFee { get; set; }
    }
}