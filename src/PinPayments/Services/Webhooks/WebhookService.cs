namespace PinPayments.Services.Webhooks
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Webhooks;

    public class WebhookService : Service
    {
        public async Task<PinList<Webhook>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Webhook>>(HttpMethod.Get, Urls.Webhooks, paginationOptions);
        }

        public async Task<Webhook> Get(string webhookToken)
        {
            if (string.IsNullOrEmpty(webhookToken))
            {
                throw new ArgumentNullException("Webhook token cannot be null or empty.");
            }

            var url = string.Format(Urls.Webhook, webhookToken);
            return await this.Execute<Webhook>(HttpMethod.Get, url);
        }

        public async Task<Webhook> Replay(string webhookToken)
        {
            if (string.IsNullOrEmpty(webhookToken))
            {
                throw new ArgumentNullException("Webhook token cannot be null or empty.");
            }

            var url = string.Format(Urls.WebhookReplay, webhookToken);
            return await this.Execute<Webhook>(HttpMethod.Put, url);
        }
    }
}