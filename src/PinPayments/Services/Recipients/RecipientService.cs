namespace PinPayments.Services.Recipients
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Recipients;
    using PinPayments.Entities.Transfers;

    public class RecipientService : Service
    {
        public async Task<Recipient> Create(RecipientCreateOptions recipientCreateOptions)
        {
            return await this.Execute<RecipientCreateOptions, Recipient>(HttpMethod.Post, Urls.Recipients, recipientCreateOptions);
        }

        public async Task<PinList<Recipient>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Recipient>>(HttpMethod.Get, Urls.Recipients, paginationOptions);
        }

        public async Task<Recipient> Get(string recipientToken)
        {
            if (string.IsNullOrEmpty(recipientToken))
            {
                throw new ArgumentNullException("Recipient token cannot be null or empty.");
            }

            var url = string.Format(Urls.Refund, recipientToken);
            return await this.Execute<Recipient>(HttpMethod.Get, url);
        }

        public async Task<Recipient> Update(string recipientToken, RecipientUpdateOptions recipientUpdateOptions = null)
        {
            if (string.IsNullOrEmpty(recipientToken))
            {
                throw new ArgumentNullException("Recipient token cannot be null or empty.");
            }

            var url = string.Format(Urls.Refund, recipientToken);
            return await this.Execute<RecipientUpdateOptions, Recipient>(HttpMethod.Put, url, recipientUpdateOptions);
        }

        public async Task<PinList<Transfer>> Transfers(string recipientToken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(recipientToken))
            {
                throw new ArgumentNullException("Recipient token cannot be null or empty.");
            }

            var url = string.Format(Urls.RecipientTransfers, recipientToken);
            return await this.Execute<PaginationOptions, PinList<Transfer>>(HttpMethod.Get, url, paginationOptions);
        }
    }
}