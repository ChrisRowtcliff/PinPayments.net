namespace PinPayments.Entities.Transfers
{
    using System;
    using System.Text.Json.Serialization;
    using PinPayments.Entities.BankAccounts;

    public class Transfer : IEvent
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("total_debits")]
        public int TotalDebits { get; set; }

        [JsonPropertyName("total_credits")]
        public int TotalCredits { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("paid_at")]
        public DateTime PaidAt { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("line_items_count")]
        public int LineItemsCount { get; set; }

        [JsonPropertyName("bank_account")]
        public BankAccount BankAccount { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; }
    }
}