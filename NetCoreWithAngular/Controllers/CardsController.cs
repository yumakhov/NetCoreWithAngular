using Microsoft.AspNetCore.Mvc;
using NetCoreWithAngular.DataContracts;
using NetCoreWithAngular.Services;

namespace NetCoreWithAngular.Controllers
{
    [ApiController]    
    public class CardsController : ControllerBase
    {

        private readonly ILogger<CardsController> _logger;
        private readonly ICardsService _cardsService;

        public CardsController(ILogger<CardsController> logger,
            ICardsService cardsService)
        {
            _logger = logger;
            _cardsService = cardsService;
        }

        [HttpGet]
        [Route("cards")]
        public IEnumerable<Card> GetAllCards()
        {
            return _cardsService.GetAll();
        }

        [HttpPost]
        [Route("cards")]
        public Card CreateCard([FromBody] Card cardData)
        {
            return _cardsService.Create(cardData);
        }

        [HttpPut]
        [Route("cards")]
        public Card UpdateCard([FromBody] Card cardData)
        {
            return _cardsService.Update(cardData);
        }
    }
}