namespace PinPayments.Services.Plans
{
    using System.Text.Json.Serialization;
    using PinPayments.Entities.Plans;

    public class PlanUpdateOptions
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("customer_permissions")]
        public CustomerPermissions[] CustomerPermissions { get; set; }
    }
}