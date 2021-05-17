namespace PinPayments.Json
{
    using PinPayments.Entities.Webhooks;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    internal class WebhookErrorSerialiser : JsonConverter<Dictionary<DateTime, WebhookError>>
    {
        public override Dictionary<DateTime, WebhookError> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var data = JsonSerializer.Deserialize<Dictionary<string, WebhookError>>(ref reader);
            var returnData = new Dictionary<DateTime, WebhookError>();
            const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
            foreach (var key in data.Keys)
            {
                var date = DateTime.MinValue;
                DateTime.TryParseExact(key, "yyyy-MM-dd hh:mm:ss UTC", CultureInfo.InvariantCulture, style, out date);
                returnData.Add(date, data[key]);
            }
            return returnData;
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<DateTime, WebhookError> value, JsonSerializerOptions options)
        {
            var data = new Dictionary<string, WebhookError>();

            foreach (var key in value.Keys)
            {
                var strKey = key.ToString("yyyy-MM-dd hh:mm:ss UTC");
                data.Add(strKey, value[key]);
            }

            var serialisedData = JsonSerializer.Serialize(data);
            writer.WriteStringValue(serialisedData);
        }
    }
}