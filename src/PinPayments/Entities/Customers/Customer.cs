namespace PinPayments.Entities.Customers
{
    using System;
    using System.Text.Json.Serialization;
    using PinPayments.Entities.Cards;

    public class Customer : IEvent
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

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

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("card")]
        public Card Card { get; set; }
    }
}