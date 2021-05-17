namespace PinPayments.Services.Plans
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Plans;
    using PinPayments.Entities.Subscriptions;

    public class PlanService : Service
    {
        public async Task<Plan> Create(PlanCreateOptions planCreateOptions)
        {
            return await this.Execute<PlanCreateOptions, Plan>(HttpMethod.Post, Urls.Plans, planCreateOptions);
        }

        public async Task<PinList<Plan>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Plan>>(HttpMethod.Get, Urls.Plans, paginationOptions);
        }

        public async Task<Plan> Get(string planToken)
        {
            if (string.IsNullOrEmpty(planToken))
            {
                throw new ArgumentNullException("Token cannot be null or empty.");
            }

            var url = string.Format(Urls.Plan, planToken);
            return await this.Execute<Plan>(HttpMethod.Get, url);
        }

        public async Task<Plan> Update(string planToken, PlanUpdateOptions planUpdateOptions)
        {
            if (string.IsNullOrEmpty(planToken))
            {
                throw new ArgumentNullException("Token cannot be null or empty.");
            }

            var url = string.Format(Urls.Plan, planToken);
            return await this.Execute<PlanUpdateOptions, Plan>(HttpMethod.Put, url, planUpdateOptions);
        }

        public async Task Delete(string planToken)
        {
            if (string.IsNullOrEmpty(planToken))
            {
                throw new ArgumentNullException("Token cannot be null or empty.");
            }

            var url = string.Format(Urls.Plan, planToken);
            await this.Execute(HttpMethod.Delete, url);
        }

        public async Task<Subscription> CreateSubscription(string planToken, PlanSubscriptionOptions planSubscriptionOptions)
        {
            if (string.IsNullOrEmpty(planToken))
            {
                throw new ArgumentNullException("Token cannot be null or empty.");
            }

            var url = string.Format(Urls.PlanSubscriptions, planToken);
            return await this.Execute<PlanSubscriptionOptions, Subscription>(HttpMethod.Post, url, planSubscriptionOptions);
        }

        public async Task<PinList<Subscription>> Subscriptions(string planToken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(planToken))
            {
                throw new ArgumentNullException("Token cannot be null or empty.");
            }

            var url = string.Format(Urls.PlanSubscriptions, planToken);
            return await this.Execute<PaginationOptions, PinList<Subscription>>(HttpMethod.Get, url, paginationOptions);
        }
    }
}