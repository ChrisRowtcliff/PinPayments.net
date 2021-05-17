namespace PinPayments.Services
{
    using System.Text.Json.Serialization;

    public class PaginationOptions
    {
        public PaginationOptions()
        {
            this.Page = 1;
        }

        [JsonPropertyName("page")]
        public int Page { get; set; }
    }
}