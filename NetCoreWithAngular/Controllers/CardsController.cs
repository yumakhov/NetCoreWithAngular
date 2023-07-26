using Mapster;
using Microsoft.AspNetCore.Mvc;
using NetCoreWithAngular.BusinessLogic.Models;
using NetCoreWithAngular.Logic.Abstract;
using NetCoreWithAngular.Models;

namespace NetCoreWithAngular.Controllers
{
    [ApiController]    
    public class CardsController : ControllerBase
    {

        private readonly ILogger<CardsController> _logger;
        private readonly ICardsService _cardsService;

        public CardsController(
            ILogger<CardsController> logger,
            ICardsService cardsService)
        {
            _logger = logger;
            _cardsService = cardsService;
        }

        [HttpGet]
        [Route("cards")]
        public IEnumerable<CardVM?> GetAllCards()
        {
            var cards = _cardsService.GetAll();

            return cards.Select(card => card?.Adapt<CardVM>());
        }

        [HttpGet]
        [Route("cards/{id}")]
        public CardVM? GetCard(Guid id)
        {
            var card = _cardsService.Get(id);

            return card?.Adapt<CardVM>();
        }

        [HttpPost]
        [Route("cards")]
        public CardVM? CreateCard([FromBody] CardDataVM cardData)
        {
            var createCardRequest = cardData.Adapt<Card>();
            var createdCard = _cardsService.Create(createCardRequest);

            return createdCard?.Adapt<CardVM>();
        }

        [HttpPut]
        [Route("cards")]
        public CardVM? UpdateCard([FromBody] CardVM cardData)
        {
            var updateCardRequest = cardData.Adapt<Card>();
            var updatedCard = _cardsService.Update(updateCardRequest);

            return updatedCard?.Adapt<CardVM>();
        }
    }
}