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
    public class TourStatusController : Controller
    {
        private readonly ITourStatusService _service;
        public TourStatusController(ITourStatusService service)
        {
            _service = service;
        }

        [HttpPost("add-tour-status")]
        public async Task<ActionResult> CreateTourStatus(TourStatusRequest model)
        {
            try
            {
                await _service.CreateTourStatusAsync(model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-tour-status/{id}")]
        public async Task<ActionResult<TourStatusResponse>> GetTourStatusById(int id)
        {
            try
            {
                return Ok(await _service.GetTourStatusByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-tour-status/{id}")]
        public async Task<ActionResult> UpdateTourStatus(int id, TourStatusResponse model)
        {
            try
            {
                await _service.UpdateTourStatusAsync(id, model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-tour-statuses")]
        public async Task<ActionResult<IEnumerable<TourStatusResponse>>> GetTourStatuses()
        {
            try
            {
                return Ok(await _service.GetTourStatusesAsync());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-tour-status/{id}")]
        public async Task<ActionResult> DeleteTourStatus(int id)
        {
            try
            {
                await _service.DeleteTourStatusAsync(id);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
