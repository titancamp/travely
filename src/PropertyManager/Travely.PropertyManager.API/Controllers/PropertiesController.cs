using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.Common.Api.Controllers;
using Travely.PropertyManager.Grpc.Client.Abstraction;
using Travely.PropertyManager.Grpc.Models;

namespace Travely.PropertyManager.API.Controllers
{
    [ApiVersion("1.0")]
    public class PropertiesController : TravelyControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyManagerClient _client;

        public PropertiesController(IMapper mapper, IPropertyManagerClient client)
        {
            _mapper = mapper;
            _client = client;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyResponseModel>> Get(int id)
        {
            var data = await _client.GetByIdAsync(UserInfo.AgencyId, id);

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyResponseModel>>> Get()
        {
            var data = await _client.GetPropertiesAsync(UserInfo.AgencyId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEditPropertyRequestModel model)
        {
            var id = await _client.AddPropertyAsync(UserInfo.AgencyId, model);

            return Created(Url.RouteUrl(id), id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddEditPropertyRequestModel model)
        {
            id = await _client.EditPropertyAsync(UserInfo.AgencyId, id, model);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeletePropertyAsync(UserInfo.AgencyId, id);

            return NoContent();
        }
    }
}
