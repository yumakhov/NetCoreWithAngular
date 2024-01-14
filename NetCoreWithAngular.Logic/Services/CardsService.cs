using Mapster;
using NetCoreWithAngular.BusinessLogic.Models;
using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Entities;
using NetCoreWithAngular.Logic.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Card> CreateAsync(Card card)
        {
            var cardDbo = card.Adapt<CardDbo>();
            var createdCardDbo = await _cardsRepository.CreateAsync(cardDbo);

            return createdCardDbo.Adapt<Card>();
        }

        public async Task<Card> UpdateAsync(Card card)
        {
            var cardDbo = card.Adapt<CardDbo>();
            var updatedCardDbo = await _cardsRepository.UpdateAsync(cardDbo);

            return updatedCardDbo.Adapt<Card>();
        }

        public async Task<Card?> GetAsync(Guid id)
        {
            var cardDbo = await _cardsRepository.GetAsync(id);

            return cardDbo?.Adapt<Card>();
        }

        public async Task<List<Card?>> GetAllAsync()
        {
            var cardDboItems = await _cardsRepository.GetAllAsync();

            return cardDboItems
                .Select(cardDbo => cardDbo?.Adapt<Card>())
                .ToList();
        }
    }
}
