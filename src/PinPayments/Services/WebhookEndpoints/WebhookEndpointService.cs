namespace PinPayments.Services.WebhookEndpoints
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Web;
    using PinPayments.Entities.WebhookEndpoints;

    public class WebhookEndpointService : Service
    {
        public async Task<PinList<WebhookEndpoint>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<WebhookEndpoint>>(HttpMethod.Get, Urls.WebhookEndpoints, paginationOptions);
        }

        public async Task<WebhookEndpoint> Get(string webhookEndpointToken)
        {
            if (string.IsNullOrEmpty(webhookEndpointToken))
            {
                throw new ArgumentNullException("Webhook Endpoint token cannot be null or empty.");
            }

            var url = string.Format(Urls.WebhookEndpoint, webhookEndpointToken);
            return await this.Execute<WebhookEndpoint>(HttpMethod.Get, url);
        }

        public async Task Delete(string webtookEndpointToken)
        {
            if (string.IsNullOrEmpty(webtookEndpointToken))
            {
                throw new ArgumentNullException("Webhook Endpoint token cannot be null or empty.");
            }

            var url = string.Format(Urls.WebhookEndpoint, webtookEndpointToken);
            await this.Execute(HttpMethod.Delete, url);
        }

        public async Task<WebhookEndpoint> Create(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException("Webhook Endpoint url cannot be null or empty.");
            }

            var webhookEndpointCreateOptions = new WebhookEndpointCreateOptions()
            {
                Url = url.ToString(),
            };
            return await this.Execute<WebhookEndpointCreateOptions, WebhookEndpoint>(HttpMethod.Post, Urls.WebhookEndpoints, webhookEndpointCreateOptions);
        }
    }
}