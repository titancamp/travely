using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Travely.Common.Api.Controllers;
using Travely.Shared.IdentityClient.Authorization.Common;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.API.Responses;
using Travely.SupplierManager.Service;

namespace Travely.SupplierManager.API.Controllers
{
    [ApiVersion("1.0")]
    // [Authorize(Roles = UserRoles.User)]
    public class SupplierController<T, TRequest, TResponse, TFilter> : TravelyControllerBase
        where T : class
        where TRequest : class
        where TResponse : class
        where TFilter : class
    {
        protected readonly IMapper Mapper;
        protected readonly ISupplierService<T, TFilter> Service;

        public SupplierController(ISupplierService<T, TFilter> service, IMapper mapper)
        {
            Service = service;
            Mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] SupplierQueryParamsResponse parameters, [FromQuery] TFilter filters)
        {
            var data = Service.Get(UserInfo.AgencyId, Mapper.Map<SupplierQueryParams>(parameters), filters);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<SupplierPageResponse<TResponse>>(data));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await Service.GetAsync(UserInfo.AgencyId, id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TResponse>(data));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TRequest request)
        {
            var model = Mapper.Map<T>(request);
            var newModel = await Service.CreateAsync(UserInfo.AgencyId, model);

            if (newModel == null)
            {
                return BadRequest();
            }

            return Created(Url.RouteUrl(newModel), Mapper.Map<TResponse>(newModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TRequest request)
        {
            var model = Mapper.Map<T>(request);
            var updatedModel = await Service.UpdateAsync(UserInfo.AgencyId, id, model);

            if (updatedModel == null)
            {
                return BadRequest();
            }

            return Ok(Mapper.Map<TResponse>(updatedModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Service.RemoveAsync(UserInfo.AgencyId, id);

            return NoContent();
        }
    }
}