namespace PinPayments.Entities.Plans
{
    using System.Text.Json.Serialization;

    public class SubscriptionCount
    {
        [JsonPropertyName("trial")]
        public int Trial { get; set; }

        [JsonPropertyName("active")]
        public int Active { get; set; }

        [JsonPropertyName("cancelling")]
        public int Cancelling { get; set; }

        [JsonPropertyName("cancelled")]
        public int Cancelled { get; set; }
    }
}