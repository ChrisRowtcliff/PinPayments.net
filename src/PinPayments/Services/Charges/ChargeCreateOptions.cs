namespace PinPayments.Services.Charges
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PinPayments.Services.Cards;

    public class ChargeCreateOptions
    {
        public ChargeCreateOptions()
        {
            this.Metadata = new Dictionary<string, string>();
            this.Capture = true;
            this.Currency = PinPaymentsConfiguration.DefaultCurrency;
        }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("ip_address")]
        public string IPAddress { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonPropertyName("three_d_secure")]
        public ThreeDSecure ThreeDSecure { get; set; }

        [JsonPropertyName("card")]
        public CardCreateOptions Card { get; set; }

        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }

        [JsonPropertyName("customer_token")]
        public string CustomerToken { get; set; }

        [JsonPropertyName("capture")]
        public bool Capture { get; set; }
    }
}