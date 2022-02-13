using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.TourManager.Core;
using Travely.TourManager.Core.Details;

namespace Travely.TourManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourTypeController : ControllerBase
    {
        private readonly ITourTypeService _service;
        public TourTypeController(ITourTypeService service)
        {
            _service = service;
        }

        [HttpPost("add-tour-type")]
        public async Task<ActionResult> CreateTourType(TourTypeRequest model)
        {
            try
            {
                await _service.CreateTourTypeAsync(model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-tour-type/{id}")]
        public async Task<ActionResult<TourTypeResponse>> GetTourTypeById(int id)
        {
            try
            {
                return Ok(await _service.GetTourTypeByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-tour-type/{id}")]
        public async Task<ActionResult> UpdateTourType(int id, TourTypeResponse model)
        {
            try
            {
                await _service.UpdateTourTypeAsync(id, model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-tour-types")]
        public async Task<ActionResult<IEnumerable<TourTypeResponse>>> GetTourTypes()
        {
            try
            {
                return Ok(await _service.GetTourTypesAsync());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-tour-type/{id}")]
        public async Task<ActionResult> DeleteTourType(int id)
        {
            try
            {
                await _service.DeleteTourTypeAsync(id);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
