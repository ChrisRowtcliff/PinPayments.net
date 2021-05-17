namespace PinPayments.Entities.Events
{
    using System.Runtime.Serialization;
    using System.Text.Json.Serialization;
    using PinPayments.Json;

    [JsonConverter(typeof(EventTypeSerialiser))]
    public enum EventType
    {
        ChargeAuthorised,

        ChargeVoided,

        ChargeCaptured,

        ChargeFailed,

        CustomerCreated,

        CustomerUpdated,

        CustomerDeleted,

        RecipientCreated,

        RecipientUpdated,

        RecipientDeleted,

        RefundCreated,

        RefundSucceeded,

        RefundFailed,

        TransferCreated,

        TransferFailed,

        PlanCreated,

        PlanDeleted,

        SubscriptionCreated,

        SubscriptionUnsubscribed,

        SubscriptionCancelled,

        SubscriptionExpired,

        SubscriptionRenewed,
    }
}