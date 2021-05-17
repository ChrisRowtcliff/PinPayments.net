namespace PinPayments.Services.Customers
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Cards;
    using PinPayments.Entities.Charges;
    using PinPayments.Entities.Customers;
    using PinPayments.Entities.Subscriptions;

    public class CustomerService : Service
    {
        public async Task<Customer> Create(CustomerCreateOptions customerCreateOptions)
        {
            var url = Urls.Customers;
            return await this.Execute<CustomerCreateOptions, Customer>(HttpMethod.Post, url, customerCreateOptions);
        }

        public async Task<PinList<Customer>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Customer>>(HttpMethod.Get, Urls.Customers, paginationOptions);
        }

        public async Task<Customer> Get(string customerToken)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.Customer, customerToken);
            return await this.Execute<Customer>(HttpMethod.Get, url);
        }

        public async Task<Customer> Update(string customerToken, CustomerUpdateOptions customerUpdateOptions)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.Customer, customerToken);
            return await this.Execute<CustomerUpdateOptions, Customer>(HttpMethod.Put, url, customerUpdateOptions);
        }

        public async Task Delete(string customerToken)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.Customer, customerToken);
            await this.Execute(HttpMethod.Delete, url);
        }

        public async Task<PinList<Charge>> Charges(string customerToken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.CustomerCharges, customerToken);
            return await this.Execute<PaginationOptions, PinList<Charge>>(HttpMethod.Get, url, paginationOptions);
        }

        public async Task<PinList<Card>> Cards(string customerToken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.CustomerCards, customerToken);
            return await this.Execute<PaginationOptions, PinList<Card>>(HttpMethod.Get, url, paginationOptions);
        }

        public async Task<PinList<Subscription>> Subscriptions(string customerToken, PaginationOptions paginationOptions = null)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.CustomerSubscriptions, customerToken);
            return await this.Execute<PaginationOptions, PinList<Subscription>>(HttpMethod.Get, url, paginationOptions);
        }

        public async Task<Card> CreateCard(string customerToken, CustomerCardCreateOptions customerCardCreateOptions)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            var url = string.Format(Urls.CustomerCards, customerToken);
            return await this.Execute<CustomerCardCreateOptions, Card>(HttpMethod.Post, url, customerCardCreateOptions);
        }

        public async Task DeleteCard(string customerToken, string cardcustomerToken)
        {
            if (string.IsNullOrEmpty(customerToken))
            {
                throw new ArgumentNullException("Customer Token cannot be null or empty.");
            }

            if (string.IsNullOrEmpty(cardcustomerToken))
            {
                throw new ArgumentNullException("Card Token cannot be null or empty.");
            }

            var url = string.Format(Urls.CustomerCard, customerToken, cardcustomerToken);
            await this.Execute(HttpMethod.Delete, url);
        }
    }
}