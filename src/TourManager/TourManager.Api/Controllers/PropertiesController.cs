using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TourManager.Api.Models.Requests;
using TourManager.Common.Clients.PropertyManager;
using TourManager.Service.Abstraction;

namespace TourManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _service;

        public PropertiesController(IMapper mapper, IPropertyService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyResponse>> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyResponse>>> Get()
        {
            var data = await _service.GetAsync();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddPropertyRequestModel model)
        {
            int? id;

            var businessModel = _mapper.Map<AddPropertyRequest>(model);

            try
            {

                id = await _service.AddAsync(businessModel);
            }
            finally
            {
                foreach (var item in businessModel.AttachmentsToAdd)
                {
                    item.Stream.Dispose();
                }
            }

            return Created(Url.RouteUrl(id), id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }
    }
}
