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
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService _service;
        public LanguageController(ILanguageService service)
        {
            _service = service;
        }

        [HttpPost("add-language")]
        public async Task<ActionResult> CreateLanguage(LanguageRequest model)
        {
            try
            {
                await _service.CreateLanguageAsync(model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-language/{id}")]
        public async Task<ActionResult<LanguageResponse>> GetRow(int id)
        {
            try
            {
                return Ok(await _service.GetLanguageByIdAsync(id));
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update-language/{id}")]
        public async Task<ActionResult> Update(int id, LanguageResponse model)
        {
            try
            {
                await _service.UpdateLanguageAsync(id, model);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get-languages")]
        public async Task<ActionResult<IEnumerable<LanguageResponse>>> GetLanguages()
        {
            try
            {
                return Ok(await _service.GetLanguagesAsync());
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete-language/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _service.DeleteLanguageAsync(id);
                return Ok();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
