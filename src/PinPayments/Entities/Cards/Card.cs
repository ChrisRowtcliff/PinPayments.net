namespace PinPayments.Entities.Cards
{
    using System.Text.Json.Serialization;

    public class Card
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("scheme")]
        public string Scheme { get; set; }

        [JsonPropertyName("display_number")]
        public string DisplayNumber { get; set; }

        [JsonPropertyName("issuing_country")]
        public string IssuingCountry { get; set; }

        [JsonPropertyName("expiry_month")]
        public int ExpiryMonth { get; set; }

        [JsonPropertyName("expiry_year")]
        public int ExpiryYear { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address_line1")]
        public string AddressLine1 { get; set; }

        [JsonPropertyName("address_line2")]
        public string AddressLine2 { get; set; }

        [JsonPropertyName("address_city")]
        public string AddressCity { get; set; }

        [JsonPropertyName("address_postcode")]
        public string AddressPostcode { get; set; }

        [JsonPropertyName("address_state")]
        public string AddressState { get; set; }

        [JsonPropertyName("address_country")]
        public string AddressCountry { get; set; }

        [JsonPropertyName("primary")]
        public bool? Primary { get; set; }
    }
}