using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using RandomCards.Business;

namespace RandomCards.Controllers
{
    [Route("api")]
    public class InfoController : Controller
    {
        private IInfo _info;
        public InfoController(IInfo info)
        {
            _info = info;
        }
    }
}
