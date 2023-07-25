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
        public IEnumerable<CardVM> GetAllCards()
        {
            var cards = _cardsService.GetAll();

            return new List<CardVM>();
        }

        [HttpGet]
        [Route("cards/{id}")]
        public CardVM? GetCard(Guid id)
        {
            var card = _cardsService.Get(id);

            return null;
        }

        [HttpPost]
        [Route("cards")]
        public CardVM CreateCard([FromBody] CardDataVM cardData)
        {
            var createdCard = _cardsService.Create(new Card());

            return null;
        }

        [HttpPut]
        [Route("cards")]
        public CardVM UpdateCard([FromBody] CardVM cardData)
        {
            var updatedCard = _cardsService.Update(new Card());

            return null;
        }
    }
}