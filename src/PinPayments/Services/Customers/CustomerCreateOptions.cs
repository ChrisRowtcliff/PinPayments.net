namespace PinPayments.Services.Customers
{
    using System.Text.Json.Serialization;
    using PinPayments.Services.Cards;

    public class CustomerCreateOptions
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("last_name")]
        public string LastName { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("notes")]
        public string Notes { get; set; }

        [JsonPropertyName("card")]
        public CardCreateOptions Card { get; set; }

        [JsonPropertyName("card_token")]
        public string CardToken { get; set; }
    }
}