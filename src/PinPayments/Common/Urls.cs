namespace PinPayments.Services
{
    internal static class Urls
    {
        // Charges
        internal const string Charges = "charges";

        internal const string ChargeVoid = "charges/{0}/void";
        internal const string ChargeCapture = "charges/{0}/capture";
        internal const string ChargeSearch = "charges/search";
        internal const string Charge = "charges/{0}";

        // Cards
        internal const string Cards = "cards";

        // Customers
        internal const string Customers = "customers";

        internal const string Customer = "customers/{0}";
        internal const string CustomerCharges = "customers/{0}/charges";
        internal const string CustomerCards = "customers/{0}/cards";
        internal const string CustomerCard = "customers/{0}/cards/{1}";
        internal const string CustomerSubscriptions = "customers/{0}/subscriptions";

        // Balances
        internal const string Balance = "balance";

        // Refunds
        internal const string Refunds = "refunds";

        internal const string Refund = "refunds/{0}";
        internal const string RefundCharge = "charges/{0}/refunds";

        // Bank Accounts
        internal const string BankAccount = "bank_accounts";

        // Events
        internal const string Events = "events";

        internal const string Event = "events/{0}";

        // Webhooks
        internal const string Webhook = "webhooks/{0}";

        internal const string Webhooks = "webhooks";
        internal const string WebhookReplay = "webhooks/{0}/replay";

        // Webhook Endpoints
        internal const string WebhookEndpoints = "webhook_endpoints";

        internal const string WebhookEndpoint = "webhook_endpoints/{0}";

        // Subscriptions
        internal const string Subscriptions = "subscriptions";

        internal const string Subscription = "subscriptions/{0}";
        internal const string SubscriptionReactivate = "subscriptions/{0}/reactivate";
        internal const string SubscriptionLedger = "subscriptions/{0}/ledger";

        // Plans
        internal const string Plans = "plans";

        internal const string Plan = "plans/{0}";
        internal const string PlanSubscriptions = "plans/{0}/subscriptions";

        // Transfers
        internal const string Transfers = "transfers";

        internal const string TransferSearch = "transfers/search";
        internal const string Transfer = "transfers/{0}";
        internal const string TransferLineItems = "transfers/{0}/line_items";

        // Recipients
        internal const string Recipients = "recipients";

        internal const string Recipient = "recipients/{0}";
        internal const string RecipientTransfers = "recipients/{0}/transfers";
    }
}