namespace PinPayments.Services.Events
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Events;

    public class EventService : Service
    {
        public async Task<PinList<Event>> List(PaginationOptions paginationOptions = null)
        {
            return await this.Execute<PaginationOptions, PinList<Event>>(HttpMethod.Get, Urls.Events, paginationOptions);
        }

        public async Task<Event> Get(string eventToken)
        {
            if (string.IsNullOrEmpty(eventToken))
            {
                throw new ArgumentNullException("Event token cannot be null or empty.");
            }

            var url = string.Format(Urls.Event, eventToken);
            return await this.Execute<Event>(HttpMethod.Get, url);
        }
    }
}