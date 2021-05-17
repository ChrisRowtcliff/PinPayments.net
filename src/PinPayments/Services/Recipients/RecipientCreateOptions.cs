namespace PinPayments.Services.Recipients
{
    using System.Text.Json.Serialization;
    using PinPayments.Services.BankAccounts;

    public class RecipientCreateOptions
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("bank_account")]
        public BankAccountCreateOptions BankAccount { get; set; }

        [JsonPropertyName("bank_account_token")]
        public string BankAccountToken { get; set; }
    }
}