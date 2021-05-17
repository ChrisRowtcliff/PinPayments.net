namespace PinPayments.Services.Subscriptions
{
    using System.Text.Json.Serialization;

    public class SubscriptionCreateOptions
    {
        public SubscriptionCreateOptions()
        {
            this.IncludeSetupFee = true;
        }

        [JsonPropertyName("plan_token")]
        public string PlanToken { get; set; }

        [JsonPropertyName("customer_token")]
        public string CustomerToken { get; set; }

        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }

        [JsonPropertyName("include_setup_fee")]
        public bool IncludeSetupFee { get; set; }
    }
}