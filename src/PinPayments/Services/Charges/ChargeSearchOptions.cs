namespace PinPayments.Services.Charges
{
    using System.Text.Json.Serialization;

    public class ChargeSearchOptions
    {
        public ChargeSearchOptions()
        {
            this.Page = 1;
        }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }
    }
}