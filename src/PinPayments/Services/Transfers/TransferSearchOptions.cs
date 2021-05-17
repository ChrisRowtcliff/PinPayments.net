namespace PinPayments.Services.Transfers
{
    using System;
    using System.Text.Json.Serialization;

    public class TransferSearchOptions : PaginationOptions
    {
        public TransferSearchOptions()
            : base()
        {
        }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("start_date")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("end_date")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("sort")]
        public string Sort
        {
            get { return "paid_at"; }
        }

        [JsonPropertyName("direction")]
        public SortOptions Direction { get; set; }
    }
}