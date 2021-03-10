using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourManager.Api.Utils;
using TourManager.Service.Abstraction;
using TourManager.Service.Model;

namespace TourManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TourController : ControllerBase
    {
        private readonly int _tenantId;
        private readonly ITourService _tourService;

        public TourController(ITourService tourService)
        {
            _tourService = tourService;
            _tenantId = int.Parse(User.FindFirst(TravelyClaimTypes.tenantId).Value);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _tourService.GetTours(_tenantId);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _tourService.GetTourById(_tenantId, id);

            if (data == null)
                return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tour tour)
        {
            var newTour = await _tourService.CreateTour(_tenantId, tour);

            if (newTour == null)
                return BadRequest();

            return Created(Url.RouteUrl(newTour.Id), newTour);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Tour tour)
        {
            var updatedTour = await _tourService.UpdateTour(_tenantId, id, tour);

            if (updatedTour == null)
                return BadRequest();

            return Ok(updatedTour);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _tourService.RemoveTour(_tenantId, id);

            return NoContent();
        }
    }
}
