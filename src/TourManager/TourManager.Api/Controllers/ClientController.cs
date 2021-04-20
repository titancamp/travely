using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TourManager.Clients.Abstraction.ClientManager;
using TourManager.Service.Model;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
	public class ClientController : TravelyControllerBase
	{
		private readonly IClientManagerServiceClient _clientManagerClient;

		public ClientController(IClientManagerServiceClient clientManagerClient)
		{
			_clientManagerClient = clientManagerClient;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var data = await _clientManagerClient.GetClientsAsync();

			if (data == null)
				return NotFound();

			return Ok(data);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			var data = await _clientManagerClient.GetClientAsync(id);

			if (data == null)
				return NotFound();

			return Ok(data);
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] Client client)
		{
			var newClient = await _clientManagerClient.CreateClientAsync(client);

			if (newClient == null)
				return BadRequest();

			return Created(Url.RouteUrl(newClient.Id), newClient);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] Client client)
		{
			var updatedClient = await _clientManagerClient.EditClientAsync(client);

			if (updatedClient == null)
				return BadRequest();

			return Ok(updatedClient);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _clientManagerClient.DeleteClientAsync(id);

			return NoContent();
		}
	}
}
