namespace PinPayments.Entities.Plans
{
    using System.Runtime.Serialization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CustomerPermissions
    {
        [EnumMember(Value = "cancel")]
        Cancel,
    }
}