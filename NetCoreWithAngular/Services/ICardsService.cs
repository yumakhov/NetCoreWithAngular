using NetCoreWithAngular.DataContracts;

namespace NetCoreWithAngular.Services
{
    public interface ICardsService
    {
        Card Create(CardData cardData);
        Card Update(Card cardData);
        Card? Get(Guid id);
        IEnumerable<Card> GetAll();
    }
}
