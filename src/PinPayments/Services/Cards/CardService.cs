namespace PinPayments.Services.Cards
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using PinPayments.Entities.Cards;

    public class CardService : Service
    {
        public async Task<Card> Create(CardCreateOptions card)
        {
            return await this.Execute<CardCreateOptions, Card>(HttpMethod.Post, Urls.Cards, card);
        }
    }
}