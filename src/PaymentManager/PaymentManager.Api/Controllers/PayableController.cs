using System.Collections.Generic;
using System.IO;
using System.Security.Policy;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentManager.Api.Dtos;
using PaymentManager.Services;
using PaymentManager.Services.Models;
using PaymentManager.Shared;
using Travely.Common.Api.Controllers;
using Travely.Shared.IdentityClient.Authorization.Common;

namespace PaymentManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.User)]
    public class PayableController : TravelyControllerBase
    {
        private readonly IPayableService _service;
        private readonly IMapper _mapper;

        public PayableController(IPayableService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/v1/payable
        [HttpGet]
        public IActionResult Get([FromQuery] PaymentQueryParametersDto parameters)
        {
            var data = _service.Get(UserInfo.AgencyId, _mapper.Map<PaymentQueryParameters>(parameters));

            if (data == null)
                return NotFound();

            return Ok(_mapper.Map<PayablePageDto>(data));
        }

        // GET: api/v1/payable/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.GetAsync(UserInfo.AgencyId, id);

            if (data == null)
                return NotFound();

            return Ok(_mapper.Map<PayableReadDetailedDto>(data));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PayableUpdateDto request)
        {
            var data = await _service.UpdateAsync(UserInfo.AgencyId, id, _mapper.Map<PayableUpdate>(request));

            if (data == null)
                return BadRequest();

            return Ok(_mapper.Map<PayableReadDetailedDto>(data));
        }
    }
}
