namespace PinPayments.Entities.Events
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json.Serialization;
    using PinPayments.Entities.Cards;

    public class EventData
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("ip_address")]
        public string IpAddress { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("status_message")]
        public string StatusMessage { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("card")]
        public Card Card { get; set; }

        [JsonPropertyName("transfer")]
        public List<Transfers.Transfer> Transfer { get; set; }

        [JsonPropertyName("amount_refunded")]
        public int AmountRefunded { get; set; }

        [JsonPropertyName("total_fees")]
        public int TotalFees { get; set; }

        [JsonPropertyName("merchant_entitlement")]
        public int MerchantEntitlement { get; set; }

        [JsonPropertyName("refund_pending")]
        public bool RefundPending { get; set; }

        [JsonPropertyName("authorisation_expired")]
        public bool AuthorisationExpired { get; set; }

        [JsonPropertyName("authorisation_voided")]
        public bool AuthorisationVoided { get; set; }

        [JsonPropertyName("captured")]
        public bool Captured { get; set; }

        [JsonPropertyName("captured_at")]
        public DateTime CapturedAt { get; set; }

        [JsonPropertyName("settlement_currency")]
        public string SettlementCurrency { get; set; }

        [JsonPropertyName("active_chargebacks")]
        public bool ActiveChargebacks { get; set; }

        [JsonPropertyName("metadata")]
        public Dictionary<string, string> Metadata { get; set; }
    }
}