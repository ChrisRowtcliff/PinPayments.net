namespace PinPayments.Json
{
    using System;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using PinPayments.Entities.Charges;
    using PinPayments.Entities.Events;
    using PinPayments.Entities.Customers;
    using PinPayments.Entities.Plans;
    using PinPayments.Entities.Recipients;
    using PinPayments.Entities.Refunds;
    using PinPayments.Entities.Subscriptions;
    using PinPayments.Entities.Transfers;

    internal class EventSerialiser : JsonConverter<Event>
    {
        public override Event Read(
            ref Utf8JsonReader reader,
            Type type,
            JsonSerializerOptions options)
        {
            Event evnt = JsonSerializer.Deserialize<Event>(
                    ref reader);

            //return targetObj;
            return BindData(evnt);
        }

        public override void Write(
            Utf8JsonWriter writer,
            Event evnt, JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, evnt);
        }

        private T DeserialiseData<T>(Event evnt)
        {
            var json = evnt.Data.GetRawText();
            return JsonSerializer.Deserialize<T>(json);
        }

        private Event BindData(Event evnt)
        {
            switch (evnt.Type)
            {
                case EventType.ChargeAuthorised:
                case EventType.ChargeCaptured:
                case EventType.ChargeFailed:
                case EventType.ChargeVoided:
                    evnt.Charge = this.DeserialiseData<Charge>(evnt);
                    break;

                case EventType.CustomerCreated:
                case EventType.CustomerDeleted:
                case EventType.CustomerUpdated:
                    evnt.Customer = this.DeserialiseData<Customer>(evnt);
                    break;

                case EventType.PlanCreated:
                case EventType.PlanDeleted:
                    evnt.Plan = this.DeserialiseData<Plan>(evnt);
                    break;

                case EventType.RecipientCreated:
                case EventType.RecipientDeleted:
                case EventType.RecipientUpdated:
                    evnt.Recipient = this.DeserialiseData<Recipient>(evnt);
                    break;

                case EventType.RefundCreated:
                case EventType.RefundFailed:
                case EventType.RefundSucceeded:
                    evnt.Refund = this.DeserialiseData<Refund>(evnt);
                    break;

                case EventType.SubscriptionCancelled:
                case EventType.SubscriptionCreated:
                case EventType.SubscriptionExpired:
                case EventType.SubscriptionRenewed:
                case EventType.SubscriptionUnsubscribed:
                    evnt.Subscription = this.DeserialiseData<Subscription>(evnt);
                    break;

                case EventType.TransferCreated:
                case EventType.TransferFailed:
                    evnt.Transfer = this.DeserialiseData<Transfer>(evnt);
                    break;
            }

            return evnt;
        }
    }
}