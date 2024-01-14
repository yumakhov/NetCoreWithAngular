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
        public async Task<IEnumerable<CardVM?>> GetAllCardsAsync()
        {
            var cards = await _cardsService.GetAllAsync();

            return cards.Select(card => card?.Adapt<CardVM>());
        }

        [HttpGet]
        [Route("cards/{id}")]
        public async Task<CardVM?> GetCardAsync(Guid id)
        {
            var card = await _cardsService.GetAsync(id);

            return card?.Adapt<CardVM>();
        }

        [HttpPost]
        [Route("cards")]
        public async Task<CardVM?> CreateCardAsync([FromBody] CardDataVM cardData)
        {
            var createCardRequest = cardData.Adapt<Card>();
            var createdCard = await _cardsService.CreateAsync(createCardRequest);

            return createdCard?.Adapt<CardVM>();
        }

        [HttpPut]
        [Route("cards")]
        public async Task<CardVM?> UpdateCardAsync([FromBody] CardVM cardData)
        {
            var updateCardRequest = cardData.Adapt<Card>();
            var updatedCard = await _cardsService.UpdateAsync(updateCardRequest);

            return updatedCard?.Adapt<CardVM>();
        }
    }
}