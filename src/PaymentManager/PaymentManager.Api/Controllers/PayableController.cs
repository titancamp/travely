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
using Travely.Common.Api.Controllers;
using Travely.Shared.IdentityClient.Authorization.Common;

namespace PaymentManager.Api.Controllers
{
    [ApiVersion("1.0")]
    //[Authorize(Roles = UserRoles.User)]
    public class PayableController : TravelyControllerBase
    {
        protected readonly IPayableService _service;
        protected readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;

        public PayableController(IPayableService service, IMapper mapper, IWebHostEnvironment environment)
        {
            _service = service;
            _mapper = mapper;
            _environment = environment;
        }

        // GET: api/v1/payment
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            System.Console.WriteLine(UserInfo.AgencyId);
            var data = await _service.GetAll(UserInfo.AgencyId);

            if (data == null || data.Count == 0)
                return NotFound();

            return Ok(_mapper.Map<List<PayableReadDto>>(data));
        }

        // GET: api/v1/payment/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.Get(UserInfo.AgencyId, id);

            if (data == null)
                return NotFound();

            return Ok(_mapper.Map<PayableReadDto>(data));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PayableUpdateDto request)
        {
            var model = _mapper.Map<PayableUpdate>(request);
            var data = await _service.Update(UserInfo.AgencyId, id, model);

            if (data == null)
                return BadRequest();

            return Ok(_mapper.Map<PayableReadDto>(data));
        }


        #region MockData

        private string JsonMockFileName
        {
            get => Path.Combine(_environment.ContentRootPath, "MockData", "PayableMockData.json");
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
                var Payables = JsonSerializer.Deserialize<List<PayableCreate>>(jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                await _service.CreateRange(UserInfo.AgencyId, Payables);
            }
        }

        #endregion
    }
}
