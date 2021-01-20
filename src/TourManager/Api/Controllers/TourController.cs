using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Travely.TourManager.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TourController : Controller
    {
        // GET: api/v1/tour
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET: api/v1/tour/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST: api/v1/tour
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        // PUT: api/v1/tour/{id}
        [HttpPut]
        [Route("")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok();
        }

        // DELETE: api/v1/tour/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}
