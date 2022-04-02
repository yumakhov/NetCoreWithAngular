using NetCoreWithAngular.DataContracts;

namespace NetCoreWithAngular.Services
{
    public class CardsService: ICardsService
    {
        public static readonly Dictionary<Guid, Card> CardsDictionary = new Dictionary<Guid, Card>();

        public Card Create(Card cardData)
        {
            if (cardData == null)
            {
                throw new ArgumentNullException(nameof(cardData));
            }

            var newCard = new Card 
            { 
                Id = Guid.NewGuid(),
                Name = cardData.Name,
                ItemsCount = cardData.ItemsCount
            };
            CardsDictionary.Add(newCard.Id, newCard);

            return newCard;
        }

        public Card Update(Card cardData)
        {
            if (cardData == null)
            {
                throw new ArgumentNullException(nameof(cardData));
            }

            var existingCard = Get(cardData.Id);
            if (existingCard == null)
            {
                throw new KeyNotFoundException($"Card is not found by id={cardData.Id}");
            }

            existingCard.Name = cardData.Name;
            existingCard.ItemsCount = cardData.ItemsCount;

            return existingCard;
        }

        public Card? Get(Guid id)
        {
            return CardsDictionary.TryGetValue(id, out var card) ? card : null;
        }

        public IEnumerable<Card> GetAll()
        {
            return CardsDictionary.Values;
        }
    }
}
