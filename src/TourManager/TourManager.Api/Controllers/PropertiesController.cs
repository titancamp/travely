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
    public class PropertiesController : TravelyControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPropertyService _service;

        public PropertiesController(IMapper mapper, IPropertyService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyResponseDto>> Get(int id)
        {
            var data = await _service.GetByIdAsync(UserInfo.AgencyId, id);

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PropertyResponseDto>>> Get()
        {
            var data = await _service.GetAsync(UserInfo.AgencyId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] AddPropertyRequestModel model)
        {
            int? id;
            var businessModel = _mapper.Map<AddPropertyRequestDto>(model);

            try
            {

                id = await _service.AddAsync(UserInfo.AgencyId, businessModel);
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromForm] EditPropertyRequestModel model)
        {
            var businessModel = _mapper.Map<EditPropertyRequestDto>(model, opt => opt.AfterMap((object src, EditPropertyRequestDto dest) => dest.Id = id));

            try
            {

                id = await _service.EditAsync(UserInfo.AgencyId, businessModel);
            }
            finally
            {
                foreach (var item in businessModel.AttachmentsToAdd)
                {
                    item.Stream.Dispose();
                }
            }

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(UserInfo.AgencyId, id);

            return NoContent();
        }
    }
}
