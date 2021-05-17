namespace PinPayments.Services.Transfers
{
    using System.Text.Json.Serialization;

    public class TransferCreateOptions
    {
        public TransferCreateOptions()
        {
            this.Currency = PinPaymentsConfiguration.DefaultCurrency;
        }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("recipient")]
        public string Recipient { get; set; }
    }
}