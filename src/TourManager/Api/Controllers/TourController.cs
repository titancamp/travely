using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Travely.TourManager.Api.Controllers
{
    [Route("api/Tour")]
    public class TourController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }
    }
}
