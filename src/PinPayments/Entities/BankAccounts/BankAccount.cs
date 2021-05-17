namespace PinPayments.Entities.BankAccounts
{
    using System.Text.Json.Serialization;

    public class BankAccount
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("bsb")]
        public string BSB { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("bank_name")]
        public string BankName { get; set; }

        [JsonPropertyName("branch")]
        public string Branch { get; set; }
    }
}