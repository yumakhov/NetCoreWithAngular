using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreWithAngular.DAL.Repositories
{
    public class CardsRepository : ICardsRepository
    {
        public static readonly ConcurrentDictionary<Guid, CardDbo> CardsDictionary = CreateDefaultCards();

        private static ConcurrentDictionary<Guid, CardDbo> CreateDefaultCards()
        {
            var dict = new[]
            {
                CreateNewCard("films", 2),
                CreateNewCard("people", 4556),
                CreateNewCard("planets", 8),
                CreateNewCard("species", 98),
                CreateNewCard("starships", 200),
                CreateNewCard("vehicles", 15)
            }.ToDictionary(card => card.Id);

            return new ConcurrentDictionary<Guid, CardDbo>(dict);
        }

        private static CardDbo CreateNewCard(string? name, int itemsCount)
        {
            return new CardDbo
            {
                Id = Guid.NewGuid(),
                Name = name,
                ItemsCount = itemsCount
            };
        }

        public async Task<CardDbo> CreateAsync(CardDbo card, CancellationToken ct = default)
        {
            return await Task.Run(() =>
                {
                    if (card == null)
                    {
                        throw new ArgumentNullException(nameof(card));
                    }

                    var newCard = CreateNewCard(card.Name, card.ItemsCount);
                    CardsDictionary.TryAdd(newCard.Id, newCard);

                    return newCard;
                }, ct);            
        }

        public async Task<CardDbo?> GetAsync(Guid id, CancellationToken ct = default)
        {
            return await Task.Run(() => CardsDictionary.TryGetValue(id, out var card) ? card : null, ct);
        }

        public async Task<List<CardDbo>> GetAllAsync(CancellationToken ct = default)
        {
            return await Task.Run(() => CardsDictionary.Values.ToList(), ct);
        }

        public async Task<CardDbo> UpdateAsync(CardDbo card, CancellationToken ct = default)
        {
            return await Task.Run(async () =>
            {
                if (card == null)
                {
                    throw new ArgumentNullException(nameof(card));
                }

                if (card.Id == Guid.Empty)
                {
                    throw new ArgumentException("Id is empty");
                }

                var existingCard = await GetAsync(card.Id);
                if (existingCard == null)
                {
                    throw new KeyNotFoundException($"Card is not found by id={card.Id}");
                }

                existingCard.Name = card.Name;
                existingCard.ItemsCount = card.ItemsCount;

                return existingCard;
            }, ct);
        }

        public Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            return Task.Run(() =>
            {
                CardsDictionary.TryRemove(id, out _);
            });
        }
    }
}
