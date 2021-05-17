namespace PinPayments.Entities.Events
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using PinPayments.Entities.Charges;
    using PinPayments.Entities.Customers;
    using PinPayments.Entities.Plans;
    using PinPayments.Entities.Recipients;
    using PinPayments.Entities.Refunds;
    using PinPayments.Entities.Subscriptions;
    using PinPayments.Entities.Transfers;

    public class Event
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("type")]
        public EventType Type { get; set; }

        [JsonPropertyName("data")]
        public JsonElement Data { get; set; }

        [JsonIgnore]
        public Charge Charge { get; set; }

        [JsonIgnore]
        public Customer Customer { get; set; }

        [JsonIgnore]
        public Plan Plan { get; set; }

        [JsonIgnore]
        public Recipient Recipient { get; set; }

        [JsonIgnore]
        public Refund Refund { get; set; }

        [JsonIgnore]
        public Subscription Subscription { get; set; }

        [JsonIgnore]
        public Transfer Transfer { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("request_token")]
        public string RequestToken { get; set; }

        [JsonPropertyName("test")]
        public bool Test { get; set; }
    }
}