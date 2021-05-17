namespace PinPayments.Services.BankAccounts
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.BankAccounts;

    public class BankAccountService : Service
    {
        public async Task<BankAccount> Create(BankAccountCreateOptions bankAccountCreateOptions)
        {
            return await this.Execute<BankAccountCreateOptions, BankAccount>(HttpMethod.Post, Urls.BankAccount, bankAccountCreateOptions);
        }
    }
}