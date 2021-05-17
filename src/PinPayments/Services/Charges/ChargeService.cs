namespace PinPayments.Services.Charges
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Charges;

    public class ChargeService : Service
    {
        public async Task<Charge> Create(ChargeCreateOptions chargeCreateOptions)
        {
            return await this.Execute<ChargeCreateOptions, Charge>(HttpMethod.Post, Urls.Charges, chargeCreateOptions);
        }

        public async Task<Charge> Void(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("Charge token cannot be null or empty.");
            }

            var url = string.Format(Urls.ChargeVoid, token);
            return await this.Execute<Charge>(HttpMethod.Put, url);
        }

        public async Task<Charge> Capture(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("Charge token cannot be null or empty.");
            }

            var url = string.Format(Urls.ChargeCapture, token);
            return await this.Execute<Charge>(HttpMethod.Put, url);
        }

        public async Task<PinList<Charge>> List(PaginationOptions paginationOptions = null)
        {
            var url = Urls.Charges;
            return await this.Execute<PaginationOptions, PinList<Charge>>(HttpMethod.Get, url, paginationOptions);
        }

        public async Task<PinList<Charge>> Search(ChargeSearchOptions chargeSearchOptions)
        {
            var url = Urls.ChargeSearch;
            return await this.Execute<ChargeSearchOptions, PinList<Charge>>(HttpMethod.Get, url, chargeSearchOptions);
        }

        public async Task<Charge> Get(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentNullException("Charge token cannot be null or empty.");
            }

            var url = string.Format(Urls.Charge, token);
            return await this.Execute<Charge>(HttpMethod.Get, url);
        }
    }
}