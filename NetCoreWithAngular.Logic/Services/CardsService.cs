using Mapster;
using NetCoreWithAngular.BusinessLogic.Models;
using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Entities;
using NetCoreWithAngular.Logic.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetCoreWithAngular.Services
{
    public class CardsService: ICardsService
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsService(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public async Task<Card> CreateAsync(Card card, CancellationToken ct = default)
        {
            var cardDbo = card.Adapt<CardDbo>();
            var createdCardDbo = await _cardsRepository.CreateAsync(cardDbo, ct);

            return createdCardDbo.Adapt<Card>();
        }

        public async Task<Card> UpdateAsync(Card card, CancellationToken ct = default)
        {
            var cardDbo = card.Adapt<CardDbo>();
            var updatedCardDbo = await _cardsRepository.UpdateAsync(cardDbo, ct);

            return updatedCardDbo.Adapt<Card>();
        }

        public async Task<Card?> GetAsync(Guid id, CancellationToken ct = default)
        {
            var cardDbo = await _cardsRepository.GetAsync(id, ct);

            return cardDbo?.Adapt<Card>();
        }

        public async Task<List<Card?>> GetAllAsync(CancellationToken ct = default)
        {
            var cardDboItems = await _cardsRepository.GetAllAsync(ct);

            return cardDboItems
                .Select(cardDbo => cardDbo?.Adapt<Card>())
                .ToList();
        }
    }
}
