using Microsoft.AspNetCore.Mvc;
using NetCoreWithAngular.DataContracts;
using NetCoreWithAngular.Services;

namespace NetCoreWithAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public IEnumerable<Card> GetAllCards()
        {
            return _cardsService.GetAll();
        }
    }
}