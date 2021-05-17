namespace PinPayments.Json
{
    using System;
    using System.Globalization;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Text.RegularExpressions;
    using PinPayments.Entities.Events;

    internal class EventTypeSerialiser : JsonConverter<EventType>
    {
        private readonly TextInfo _textInfo;

        public EventTypeSerialiser()
        {
            this._textInfo = new CultureInfo("en-US", false).TextInfo;
        }

        public override EventType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var strValue = reader.GetString();
            strValue = strValue.Replace(".", " ");
            strValue = this._textInfo.ToTitleCase(strValue);
            strValue = strValue.Replace(" ", string.Empty);
            return (EventType)Enum.Parse(typeof(EventType), strValue);
        }

        public override void Write(Utf8JsonWriter writer, EventType value, JsonSerializerOptions options)
        {
            var strEventType = value.ToString();
            var parts = this.SplitCamelCase(strEventType);
            var pinpaymentsValue = string.Join(".", parts).ToLower();
            writer.WriteStringValue(pinpaymentsValue);
        }

        private string[] SplitCamelCase(string source)
        {
            return Regex.Split(source, @"(?<!^)(?=[A-Z])");
        }
    }
}