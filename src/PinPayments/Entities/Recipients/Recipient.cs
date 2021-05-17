namespace PinPayments.Entities.Recipients
{
    using System;
    using System.Text.Json.Serialization;
    using PinPayments.Entities.BankAccounts;

    public class Recipient : IEvent
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; }
    }
}