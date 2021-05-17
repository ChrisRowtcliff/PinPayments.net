namespace PinPayments.Services.Subscriptions
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Subscriptions;

    public class SubscriptionService : Service
    {
        public async Task<Subscription> Create(SubscriptionCreateOptions subscriptionCreateOptions)
        {
            return await this.Execute<SubscriptionCreateOptions, Subscription>(HttpMethod.Post, Urls.Subscriptions, subscriptionCreateOptions);
        }

        public async Task<PinList<Subscription>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Subscription>>(HttpMethod.Get, Urls.Subscriptions, paginationOptions);
        }

        public async Task<Subscription> Get(string subscriptionToken)
        {
            if (string.IsNullOrEmpty(subscriptionToken))
            {
                throw new ArgumentNullException("Subscription token cannot be null or empty.");
            }

            var url = string.Format(Urls.Subscription, subscriptionToken);
            return await this.Execute<Subscription>(HttpMethod.Get, url);
        }

        public async Task<Subscription> Update(string subscriptionToken, string cardToken)
        {
            if (string.IsNullOrEmpty(subscriptionToken))
            {
                throw new ArgumentNullException("Subscription token cannot be null or empty.");
            }

            SubscriptionUpdateOptions subscriptionUpdateOptions = new SubscriptionUpdateOptions()
            {
                CardToken = cardToken,
            };

            var url = string.Format(Urls.Subscription, subscriptionToken);
            return await this.Execute<SubscriptionUpdateOptions, Subscription>(HttpMethod.Put, url, subscriptionUpdateOptions);
        }

        public async Task Delete(string subscriptionToken)
        {
            if (string.IsNullOrEmpty(subscriptionToken))
            {
                throw new ArgumentNullException("Subscription token cannot be null or empty.");
            }

            var url = string.Format(Urls.Subscription, subscriptionToken);
            await this.Execute(HttpMethod.Delete, url);
        }

        public async Task<Subscription> Reactivate(string subscriptionToken, bool includeSetupFee = true)
        {
            if (string.IsNullOrEmpty(subscriptionToken))
            {
                throw new ArgumentNullException("Subscription token cannot be null or empty.");
            }

            var url = string.Format(Urls.SubscriptionReactivate, subscriptionToken);
            var subscriptionReactivateOptions = new SubscriptionReactivateOptions()
            {
                IncludeSetupFee = includeSetupFee,
            };
            return await this.Execute<SubscriptionReactivateOptions, Subscription>(HttpMethod.Put, url, subscriptionReactivateOptions);
        }

        public async Task<PinList<Ledger>> Ledger(string subscriptionToken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(subscriptionToken))
            {
                throw new ArgumentNullException("Subscription token cannot be null or empty.");
            }

            var url = string.Format(Urls.SubscriptionLedger, subscriptionToken);
            return await this.Execute<PaginationOptions, PinList<Ledger>>(HttpMethod.Get, url, paginationOptions);
        }
    }
}