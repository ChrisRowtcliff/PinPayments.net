namespace PinPayments.Services.BankAccounts
{
    using System.Text.Json.Serialization;

    public class BankAccountCreateOptions
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("bsb")]
        public string BSB { get; set; }

        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}