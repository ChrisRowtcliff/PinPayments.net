namespace PinPayments.Services.Balance
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Balances;

    public class BalanceService : Service
    {
        public async Task<AccountBalance> Get()
        {
            return await this.Execute<AccountBalance>(HttpMethod.Get, Urls.Balance);
        }
    }
}