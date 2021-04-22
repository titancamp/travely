using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TourManager.Service.Abstraction;
using TourManager.Service.Model.PropertyManager;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
    public class PropertiesController : TravelyControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _service;

        public PropertiesController(IMapper mapper, IPropertyService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddEditPropertyRequestModel model)
        {

            var id = await _service.AddAsync(UserInfo.AgencyId, model);

            return Created(Url.RouteUrl(id), id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] AddEditPropertyRequestModel model)
        {
            id = await _service.EditAsync(UserInfo.AgencyId, id, model);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(UserInfo.AgencyId, id);

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyResponseModel>> Get(int id)
        {
            var data = await _service.GetByIdAsync(UserInfo.AgencyId, id);

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyResponseModel>>> Get()
        {
            var data = await _service.GetAsync(UserInfo.AgencyId);

            return Ok(data);
        }

        [HttpGet("RoomTypes")]
        public async Task<ActionResult<IEnumerable<PropertyResponseModel>>> GetRoomTypes()
        {
            var data = await _service.GetRoomTypesAsync();

            return Ok(data);
        }
    }
}
