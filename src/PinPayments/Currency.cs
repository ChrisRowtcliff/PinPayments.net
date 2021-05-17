namespace PinPayments
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum Currency
    {
        AUD,
        USD,
        NZD,
        SGD,
        EUR,
        GBP,
        CAD,
        HKD,
        JPY,
        MYR,
        THB,
        PHP,
        ZAR,
        IDR,
        TWD,
    }
}