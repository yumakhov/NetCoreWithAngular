using Mapster;
using Microsoft.AspNetCore.Mvc;
using NetCoreWithAngular.BusinessLogic.Models;
using NetCoreWithAngular.Logic.Abstract;
using NetCoreWithAngular.Models;

namespace NetCoreWithAngular.Controllers
{
    [Route("cards")]
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
        public async Task<IEnumerable<CardVM?>> GetAllCardsAsync(CancellationToken ct)
        {
            var cards = await _cardsService.GetAllAsync(ct);

            return cards.Select(card => card?.Adapt<CardVM>());
        }

        [HttpGet("{id}")]
        public async Task<CardVM?> GetCardAsync(Guid id, CancellationToken ct)
        {
            var card = await _cardsService.GetAsync(id, ct);

            return card?.Adapt<CardVM>();
        }

        [HttpPost]
        public async Task<CardVM?> CreateCardAsync([FromBody] CardDataVM cardData, CancellationToken ct)
        {
            var createCardRequest = cardData.Adapt<Card>();
            var createdCard = await _cardsService.CreateAsync(createCardRequest, ct);

            return createdCard?.Adapt<CardVM>();
        }

        [HttpPut]
        public async Task<CardVM?> UpdateCardAsync([FromBody] CardVM cardData, CancellationToken ct)
        {
            var updateCardRequest = cardData.Adapt<Card>();
            var updatedCard = await _cardsService.UpdateAsync(updateCardRequest, ct);

            return updatedCard?.Adapt<CardVM>();
        }
    }
}