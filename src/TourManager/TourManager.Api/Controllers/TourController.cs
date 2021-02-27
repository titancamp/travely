using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Clients.Implementation.ServiceManager;


namespace TourManager.Api.Controllers
{
	[ApiController]
	[ApiVersion("1.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	public class TourController : Controller
	{
		private readonly IServiceManagerClient _serviceManagerClient;
		public TourController(IServiceManagerClient serviceManagerClient)
        {
			_serviceManagerClient = serviceManagerClient;
        }

		// GET: api/v1/tour
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok();
		}

		// GET: api/v1/tour/{id}
		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{

			var aa = await _serviceManagerClient.GetActivitiesAsync(1);

			return Ok(aa.ToList());
		}

		// POST: api/v1/tour
		[HttpPost]
		public async Task<IActionResult> Post()
		{
			return Ok();
		}

		// PUT: api/v1/tour/{id}
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id)
		{
			return Ok();
		}

		// DELETE: api/v1/tour/{id}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok();
		}
	}
}
