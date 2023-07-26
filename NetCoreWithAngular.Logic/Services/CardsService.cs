using Mapster;
using NetCoreWithAngular.BusinessLogic.Models;
using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Entities;
using NetCoreWithAngular.Logic.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetCoreWithAngular.Services
{
    public class CardsService: ICardsService
    {
        private readonly ICardsRepository _cardsRepository;

        public CardsService(ICardsRepository cardsRepository)
        {
            _cardsRepository = cardsRepository;
        }

        public Card Create(Card card)
        {
            var cardDbo = card.Adapt<CardDbo>();
            var createdCardDbo = _cardsRepository.Create(cardDbo);

            return createdCardDbo.Adapt<Card>();
        }

        public Card Update(Card card)
        {
            var cardDbo = card.Adapt<CardDbo>();
            var updatedCardDbo = _cardsRepository.Update(cardDbo);

            return updatedCardDbo.Adapt<Card>();
        }

        public Card? Get(Guid id)
        {
            var cardDbo = _cardsRepository.Get(id);

            return cardDbo?.Adapt<Card>();
        }

        public List<Card?> GetAll()
        {
            var cardDboItems = _cardsRepository.GetAll();

            return cardDboItems
                .Select(cardDbo => cardDbo?.Adapt<Card>())
                .ToList();
        }
    }
}
