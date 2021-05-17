namespace PinPayments.Services.Plans
{
    using System.Text.Json.Serialization;
    using PinPayments.Entities.Plans;

    public class PlanCreateOptions
    {
        public PlanCreateOptions()
        {
            this.Currency = PinPaymentsConfiguration.DefaultCurrency;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("setup_amount")]
        public int? SetupAmount { get; set; }

        [JsonPropertyName("trial_amount")]
        public int? TrialAmount { get; set; }

        [JsonPropertyName("interval")]
        public int Interval { get; set; }

        [JsonPropertyName("interval_unit")]
        public PlanIntervalUnit IntervalUnit { get; set; }

        [JsonPropertyName("intervals")]
        public int? Intervals { get; set; }

        [JsonPropertyName("trial_interval")]
        public int? TrialInterval { get; set; }

        [JsonPropertyName("trial_interval_unit")]
        public PlanIntervalUnit? TrialIntervalUnit { get; set; }

        [JsonPropertyName("customer_permissions")]
        public CustomerPermissions[]? CustomerPermissions { get; set; }
    }
}