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
    public class TourController : ControllerBase
    {
        private readonly ITourService _service;
        public TourController(ITourService service)
        {
            _service = service;
        }

        [HttpPost("add-tour")]
        public async Task<ActionResult<CreateTourResponse>> CreateTour(TourDataRequest model)
        {
            try
            {
                await _service.CreateTourAsync(model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-tour/{id}")]
        public async Task<ActionResult<TourDataResponse>> GetTour(int id)
        {
            try
            {
                return Ok(await _service.GetTourByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-tour/{id}")]
        public async Task<ActionResult> Update(int id, TourDataRequest model)
        {
            try
            {
                await _service.UpdateTourAsync(id, model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-tours")]
        public async Task<ActionResult<IEnumerable<TourDataResponse>>> GetTours()
        {
            try
            {
                return Ok(await _service.GetToursAsync());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-tour/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteTourAsync(id);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
