namespace PinPayments.Entities.Transfers
{
    using System.Text.Json.Serialization;

    public class Record
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("total_fees")]
        public int TotalFees { get; set; }

        [JsonPropertyName("merchant_entitlement")]
        public int MerchantEntitlement { get; set; }
    }
}