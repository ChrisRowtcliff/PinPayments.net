namespace PinPayments.Entities
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    internal class PinResponse : IPinResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; set; }

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }

        [JsonPropertyName("messages")]
        public List<PinErrorMessage> Messages { get; set; }

        [JsonPropertyName("pagination")]
        public Pagination Pagination { get; set; }
    }

    internal class PinResponse<T> : PinResponse
    {
        [JsonPropertyName("response")]
        public T Response { get; set; }
    }
}