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
    //[Authorize(Roles = UserRoles.User)]
    public class ReceivableController : TravelyControllerBase
    {
        protected readonly IReceivableService _service;
        protected readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public ReceivableController(IReceivableService service, IMapper mapper, IWebHostEnvironment environment)
        {
            _service = service;
            _mapper = mapper;
            _environment = environment;
        }

        // GET: api/v1/payment
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PaymentQueryParametersDto parameters)
        {
            var data = await _service.Get(UserInfo.AgencyId, _mapper.Map<PaymentQueryParameters>(parameters));

            if (data == null)
                return NotFound();

            return Ok(_mapper.Map<ReceivablePageDto>(data));
        }

        // GET: api/v1/payment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.Get(UserInfo.AgencyId, id);

            if (data == null)
                return NotFound();

            return Ok(_mapper.Map<ReceivableReadDetailedDto>(data));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ReceivableUpdateDto request)
        {
            var model = _mapper.Map<ReceivableUpdate>(request);
            var data = await _service.Update(UserInfo.AgencyId, id, model);

            if (data == null)
                return BadRequest();

            return Ok(_mapper.Map<ReceivableReadDetailedDto>(data));
        }

        #region MockData

        private string JsonMockFileName
        {
            get => Path.Combine(_environment.ContentRootPath, "MockData", "ReceivableMockData.json");
            set => _ = value;
        }

        /// <summary>
        /// This API is created for mocking only, make sure to call it once :)
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task Post()
        {
            await loadMockData();
        }

        private async Task loadMockData()
        {
            if (!System.IO.File.Exists(JsonMockFileName))
            {
                return;
            }
            using (var jsonFileReader = System.IO.File.OpenText(JsonMockFileName))
            {
                var Receivables = JsonSerializer.Deserialize<List<ReceivableCreate>>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                await _service.CreateRange(UserInfo.AgencyId, Receivables);
            }
        }

        #endregion
    }
}
