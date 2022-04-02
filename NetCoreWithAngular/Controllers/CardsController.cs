using Microsoft.AspNetCore.Mvc;
using NetCoreWithAngular.DataContracts;

namespace NetCoreWithAngular.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CardsController : ControllerBase
    {

        private readonly ILogger<CardsController> _logger;

        public CardsController(ILogger<CardsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Card> GetAllCards()
        {
            return Enumerable.Empty<Card>();
        }
    }
}