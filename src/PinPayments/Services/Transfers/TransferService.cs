namespace PinPayments.Services.Transfers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Transfers;

    public class TransferService : Service
    {
        public async Task<Transfer> Create(TransferCreateOptions transferCreateOptions)
        {
            return await this.Execute<TransferCreateOptions, Transfer>(HttpMethod.Post, Urls.Transfers, transferCreateOptions);
        }

        public async Task<PinList<Transfer>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Transfer>>(HttpMethod.Get, Urls.Transfers, paginationOptions);
        }

        public async Task<Transfer> Get(string transferToken)
        {
            if (string.IsNullOrEmpty(transferToken))
            {
                throw new ArgumentNullException("Transfer token cannot be null or empty.");
            }

            var url = string.Format(Urls.Transfer, transferToken);
            return await this.Execute<Transfer>(HttpMethod.Get, url);
        }

        public async Task<PinList<Transfer>> Search(TransferSearchOptions transferSearchOptions)
        {
            return await this.Execute<TransferSearchOptions, PinList<Transfer>>(HttpMethod.Get, Urls.TransferSearch, transferSearchOptions);
        }

        public async Task<PinList<LineItem>> ListLineItems(string transferToken, PaginationOptions options = null)
        {
            if (string.IsNullOrEmpty(transferToken))
            {
                throw new ArgumentNullException("Transfer token cannot be null or empty.");
            }

            var url = string.Format(Urls.Transfer, transferToken);
            return await this.Execute<PaginationOptions, PinList<LineItem>>(HttpMethod.Get, url, options);
        }
    }
}