using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;
using TourManager.Service.Abstraction;

namespace TourManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _service;

        public PropertiesController(IPropertyService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<PropertyResponse>> Get()
        {
            var data = await _service.GetAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddPropertyRequest model)
        {
            var id = await _service.AddAsync(model);

            return Created(Url.RouteUrl(id), id);
        }
    }
}
