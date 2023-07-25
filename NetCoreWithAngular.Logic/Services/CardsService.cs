using NetCoreWithAngular.BusinessLogic.Models;
using NetCoreWithAngular.DAL.Abstract;
using NetCoreWithAngular.DAL.Entities;
using NetCoreWithAngular.Logic.Abstract;
using System;
using System.Collections.Generic;

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
            var createdCardDbo = _cardsRepository.Create(new CardDbo());

            return new Card();
        }

        public Card Update(Card cardData)
        {
            var updatedCardDbo = _cardsRepository.Update(new CardDbo());

            return new Card();
        }

        public Card? Get(Guid id)
        {
            var cardDbo = _cardsRepository.Get(id);

            return new Card();
        }

        public List<Card> GetAll()
        {
            var cardDboItems = _cardsRepository.GetAll();

            return new List<Card>();
        }
    }
}
