namespace PinPayments.Entities
{
    using System.Collections.Generic;
    using System.Text.Json.Serialization;

    public class PinErrorMessage
    {
        [JsonPropertyName("param")]
        public string Param { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}