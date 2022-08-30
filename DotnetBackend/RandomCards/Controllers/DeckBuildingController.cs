using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomCards.Business;

namespace RandomCards.Controllers
{
    [Route("api")]
    public class DeckBuildingController : Controller
    {
        private IDeckBuilding _deckBuilding;
        public DeckBuildingController(IDeckBuilding deckBuilding)
        {
            _deckBuilding = deckBuilding;
        }

        [HttpGet]
        [Route("classes")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "DeckBuilding")]
        public IActionResult GetClasses()
        {
            return Ok(_deckBuilding.GetClasses());
        }
    }
}
