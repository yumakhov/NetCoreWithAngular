using NetCoreWithAngular.DataContracts;

namespace NetCoreWithAngular.Services
{
    public class CardsService: ICardsService
    {
        public static readonly Dictionary<Guid, Card> CardsDictionary = CreateDefaultCards();

        private static Dictionary<Guid, Card> CreateDefaultCards()
        {
            return new[]
            {
                CreateNewCard("films", 2),
                CreateNewCard("people", 4556),
                CreateNewCard("planets", 8),
                CreateNewCard("species", 98),
                CreateNewCard("starships", 200),
                CreateNewCard("vehicles", 15)
            }.ToDictionary(card => card.Id);
        }

        public Card Create(CardData cardData)
        {
            if (cardData == null)
            {
                throw new ArgumentNullException(nameof(cardData));
            }

            var newCard = CreateNewCard(cardData.Name, cardData.ItemsCount);
            CardsDictionary.Add(newCard.Id, newCard);

            return newCard;
        }

        private static Card CreateNewCard(string name, int itemsCount)
        {
            return new Card
            {
                Id = Guid.NewGuid(),
                Name = name,
                ItemsCount = itemsCount
            };
        }

        public Card Update(Card cardData)
        {
            if (cardData == null)
            {
                throw new ArgumentNullException(nameof(cardData));
            }

            if (cardData.Id == Guid.Empty)
            {
                throw new ArgumentException("Id is empty");
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
