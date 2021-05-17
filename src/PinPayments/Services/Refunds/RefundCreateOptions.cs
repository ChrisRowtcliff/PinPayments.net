namespace PinPayments.Services.Refunds
{
    using System.Text.Json.Serialization;

    internal class RefundCreateOptions
    {
        [JsonPropertyName("amount")]
        public int? Amount { get; set; }
    }
}