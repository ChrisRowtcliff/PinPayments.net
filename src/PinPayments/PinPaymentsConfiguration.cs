namespace PinPayments
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using PinPayments.Services;

    public static class PinPaymentsConfiguration
    {
        private static HttpClient httpClient;
        private static Currency defaultCurrency = Currency.AUD;

        internal static Currency DefaultCurrency
        {
            get
            {
                return defaultCurrency;
            }
        }

        internal static HttpClient Client
        {
            get
            {
                return httpClient;
            }
        }

        public static void Initialise(string apiKey, PinEnvironment environment = PinEnvironment.Test, Currency currency = Currency.AUD)
        {
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentNullException("Pin Payments ApiKey cannot be null or empty.");
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            var client = new HttpClient();
            var url = environment == PinEnvironment.Live ? Constants.LiveUrl : Constants.TestUrl;

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Add("ContentType", "application/json");

            var base64ApiKey = Convert.ToBase64String(Encoding.Default.GetBytes(apiKey + ":"));
            var authorisationHeader = $"Basic {base64ApiKey}";
            client.DefaultRequestHeaders.Add("Authorization", authorisationHeader);
            client.DefaultRequestHeaders.Add("User-Agent", "PinPayments .net Client");
            httpClient = client;
            defaultCurrency = currency;
        }
    }
}