using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PaymentManager.WebApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PayableController : ControllerBase
    {
        // GET: api/v1/payable
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
        }

        // GET: api/v1/payable/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

        // POST: api/v1/payable
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        // PUT: api/v1/payable/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            return Ok();
        }

        // DELETE: api/v1/payable/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }
    }
}