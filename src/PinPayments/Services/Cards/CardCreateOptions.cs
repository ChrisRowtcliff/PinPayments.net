namespace PinPayments.Services.Cards
{
    using System.Text.Json.Serialization;

    public class CardCreateOptions
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("expiry_month")]
        public int ExpiryMonth { get; set; }

        [JsonPropertyName("expiry_year")]
        public int ExpiryYear { get; set; }

        [JsonPropertyName("cvc")]
        public string CVC { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address_line1")]
        public string Address1 { get; set; }

        [JsonPropertyName("address_line2")]
        public string Address2 { get; set; }

        [JsonPropertyName("address_city")]
        public string City { get; set; }

        [JsonPropertyName("address_postcode")]
        public string Postcode { get; set; }

        [JsonPropertyName("address_state")]
        public string State { get; set; }

        [JsonPropertyName("address_country")]
        public string Country { get; set; }
    }
}