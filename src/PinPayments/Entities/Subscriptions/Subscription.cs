namespace PinPayments.Entities.Subscriptions
{
    using System;
    using System.Text.Json.Serialization;

    public class Subscription : IEvent
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("next_billing_date")]
        public DateTime? NextBillingDate { get; set; }

        [JsonPropertyName("active_interval_started_at")]
        public DateTime ActiveIntervalStartedAt { get; set; }

        [JsonPropertyName("active_interval_finishes_at")]
        public DateTime ActiveIntervalFinishesAt { get; set; }

        [JsonPropertyName("cancelled_at")]
        public DateTime? CancelledAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("plan_token")]
        public string PlanToken { get; set; }

        [JsonPropertyName("customer_token")]
        public string CustomerToken { get; set; }

        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }
    }
}