namespace PinPayments.Entities.Charges
{
    using System;
    using System.Text.Json.Serialization;

    public class ChargeTransfer
    {
        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("paid_at")]
        public DateTime PaidAt { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}