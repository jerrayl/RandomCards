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

        [HttpGet]
        [Route("decks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "DeckBuilding")]
        public IActionResult GetDecks(int accountId)
        {
            var decks = _deckBuilding.GetDecks(accountId);
            return Ok(decks);
        }

        [HttpPost]
        [Route("deck")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "DeckBuilding")]
        public IActionResult CreateDeck(int accountId, string className, string deckName)
        {
            var deck = _deckBuilding.CreateDeck(accountId, className, deckName, out string errorMessage);
            if (errorMessage != null)
                return BadRequest(errorMessage);
            return Ok(deck);
        }

        [HttpGet]
        [Route("card")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "DeckBuilding")]
        public IActionResult GetDeckCards(int accountId, string deckIdentifier)
        {
            var deck = _deckBuilding.GetDeckCards(accountId, deckIdentifier, out string errorMessage);
            if (errorMessage != null)
                return BadRequest(errorMessage);
            return Ok(deck);
        }

        [HttpPost]
        [Route("selectCard")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "DeckBuilding")]
        public IActionResult SelectCard(int accountId, string deckIdentifier, string cardIdentifier)
        {
            _deckBuilding.SelectCard(accountId, cardIdentifier, out string errorMessage);
            if (errorMessage != null)
                return BadRequest(errorMessage);
            return NoContent();
        }

        // TEMP FOR TESTING

        [HttpGet]
        [Route("accounts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ApiExplorerSettings(GroupName = "DeckBuilding")]
        public IActionResult GetAccountIds()
        {
            return Ok(_deckBuilding.GetAccountIds());
        }
    }
}
