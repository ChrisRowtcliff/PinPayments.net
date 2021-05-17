namespace PinPayments.Entities.Balances
{
    using System.Text.Json.Serialization;

    public class Balance
    {
        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public Currency Currency { get; set; }
    }
}