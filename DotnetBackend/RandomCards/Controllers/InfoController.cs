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
    }
}
