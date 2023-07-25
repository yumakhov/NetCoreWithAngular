using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWithAngular.DAL.Repositories
{
    public class CardsRepository : ICardsRepository
    {
        public static readonly Dictionary<Guid, CardDbo> CardsDictionary = CreateDefaultCards();

        private static Dictionary<Guid, CardDbo> CreateDefaultCards()
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

        private static CardDbo CreateNewCard(string name, int itemsCount)
        {
            return new CardDbo
            {
                Id = Guid.NewGuid(),
                Name = name,
                ItemsCount = itemsCount
            };
        }

        public CardDbo Create(CardDbo card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            var newCard = CreateNewCard(card.Name, card.ItemsCount);
            CardsDictionary.Add(newCard.Id, newCard);

            return newCard;
        }

        public CardDbo? Get(Guid id)
        {
            return CardsDictionary.TryGetValue(id, out var card) ? card : null;
        }

        public List<CardDbo> GetAll()
        {
            return CardsDictionary.Values.ToList();
        }

        public CardDbo Update(CardDbo card)
        {
            if (card == null)
            {
                throw new ArgumentNullException(nameof(card));
            }

            if (card.Id == Guid.Empty)
            {
                throw new ArgumentException("Id is empty");
            }

            var existingCard = Get(card.Id);
            if (existingCard == null)
            {
                throw new KeyNotFoundException($"Card is not found by id={card.Id}");
            }

            existingCard.Name = card.Name;
            existingCard.ItemsCount = card.ItemsCount;

            return existingCard;
        }
    }
}
