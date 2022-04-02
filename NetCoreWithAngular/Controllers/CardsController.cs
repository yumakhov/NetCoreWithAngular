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
    }
}