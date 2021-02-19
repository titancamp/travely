using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourManager.Service.Abstraction;
using TourManager.Service.Model;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _tourService.GetTours(TenantId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _tourService.GetTourById(TenantId, id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tour tour)
        {
            var newTour = await _tourService.CreateTour(TenantId, tour);

            if (newTour == null)
                return BadRequest();

            return Created(Url.RouteUrl(newTour.Id), newTour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tour tour)
        {
            var updatedTour = await _tourService.UpdateTour(TenantId, id, tour);

            if (updatedTour == null)
                return BadRequest();

            return Ok(updatedTour);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourService.RemoveTour(TenantId, id);

            return NoContent();
        }
    }
}
