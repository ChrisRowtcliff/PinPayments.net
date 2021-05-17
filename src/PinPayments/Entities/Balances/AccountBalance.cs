namespace PinPayments.Entities.Balances
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class AccountBalance
    {
        [JsonPropertyName("available")]
        public List<Balance> Available { get; set; }

        [JsonPropertyName("pending")]
        public List<Balance> Pending { get; set; }
    }
}