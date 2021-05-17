namespace PinPayments.Services.Refunds
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Refunds;

    public class RefundService : Service
    {
        public async Task<PinList<Refund>> ChargeRefunds(string chargetoken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(chargetoken))
            {
                throw new ArgumentNullException("Charge token cannot be null or empty.");
            }

            var url = string.Format(Urls.RefundCharge, chargetoken);
            return await this.Execute<PaginationOptions, PinList<Refund>>(HttpMethod.Get, url, paginationOptions);
        }

        public async Task<PinList<Refund>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Refund>>(HttpMethod.Get, Urls.Refunds, paginationOptions);
        }

        public async Task<Refund> Get(string refundToken)
        {
            if (string.IsNullOrEmpty(refundToken))
            {
                throw new ArgumentNullException("Refund token cannot be null or empty.");
            }

            var url = string.Format(Urls.Refund, refundToken);
            return await this.Execute<Refund>(HttpMethod.Get, url);
        }

        public async Task<Refund> Create(string chargeToken, int amount)
        {
            if (string.IsNullOrEmpty(chargeToken))
            {
                throw new ArgumentNullException("Charge token cannot be null or empty.");
            }

            var url = string.Format(Urls.RefundCharge, chargeToken);
            var refundCreateOptions = new RefundCreateOptions() { Amount = amount };
            return await this.Execute<RefundCreateOptions, Refund>(HttpMethod.Post, url, refundCreateOptions);
        }

        public async Task<Refund> Create(string chargeToken)
        {
            if (string.IsNullOrEmpty(chargeToken))
            {
                throw new ArgumentNullException("Charge token cannot be null or empty.");
            }

            var url = string.Format(Urls.RefundCharge, chargeToken);
            var refundCreateOptions = new RefundCreateOptions() { Amount = null };
            return await this.Execute<RefundCreateOptions, Refund>(HttpMethod.Post, url, refundCreateOptions);
        }
    }
}