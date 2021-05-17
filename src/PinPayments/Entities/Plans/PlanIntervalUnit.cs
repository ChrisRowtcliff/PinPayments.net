namespace PinPayments.Entities.Plans
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PlanIntervalUnit
    {
        [EnumMember(Value = "day")]
        Day,

        [EnumMember(Value = "week")]
        Week,

        [EnumMember(Value = "month")]
        Month,

        [EnumMember(Value = "year")]
        Year,
    }
}