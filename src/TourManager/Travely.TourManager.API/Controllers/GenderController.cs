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
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _service;
        public GenderController(IGenderService service)
        {
            _service = service;
        }

        [HttpPost("add-gender")]
        public async Task<ActionResult> CreateGender(GenderRequest model)
        {
            try
            {
                await _service.CreateGenderAsync(model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-gender/{id}")]
        public async Task<ActionResult<GenderResponse>> GetGenderById(int id)
        {
            try
            {
                return Ok(await _service.GetGenderByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-gender/{id}")]
        public async Task<ActionResult> UpdateGender(int id, GenderResponse model)
        {
            try
            {
                await _service.UpdateGenderAsync(id, model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-genders")]
        public async Task<ActionResult<IEnumerable<GenderResponse>>> GetGenders()
        {
            try
            {
                return Ok(await _service.GetGendersAsync());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-gender/{id}")]
        public async Task<ActionResult> DeleteGender(int id)
        {
            try
            {
                await _service.DeleteGenderAsync(id);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
