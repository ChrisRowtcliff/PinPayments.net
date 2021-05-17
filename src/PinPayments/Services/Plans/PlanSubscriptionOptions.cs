namespace PinPayments.Services.Plans
{
    using System.Text.Json.Serialization;

    public class PlanSubscriptionOptions
    {
        public PlanSubscriptionOptions()
        {
            this.IncludeSetupFee = true;
        }

        [JsonPropertyName("customer_token")]
        public string CustomerToken { get; set; }

        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }

        [JsonPropertyName("include_setup_fee")]
        public bool IncludeSetupFee { get; set; }
    }
}