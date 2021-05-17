namespace PinPayments.Services.Charges
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PinPayments.Services.Cards;

    public class ThreeDSecure
    {
        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("eci")]
        public string ECI { get; set; }

        [JsonPropertyName("cavv")]
        public string CAVV { get; set; }

        [JsonPropertyName("transaction_id")]
        public string TransactionId { get; set; }
    }
}