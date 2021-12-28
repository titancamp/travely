using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SupplierManager.API.ControllerFactory;
using SupplierManager.Service.Abstraction;

namespace SupplierManager.API.Controllers
{
    [ApiController]
    [GenericControllerNameConvention]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class SupplierController<T, TRequest, TResponse> : ControllerBase
        where T : class
        where TRequest : class
        where TResponse : class
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService<T> _service;

        public SupplierController(ISupplierService<T> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAll();
            if (data == null || data.Count == 0) return NotFound();

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _service.Get(id);

            if (data == null) return NotFound();

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TRequest request)
        {
            var model = _mapper.Map<TRequest, T>(request);
            var newModel = await _service.Create(model);

            if (newModel == null) return BadRequest();

            return Created(Url.RouteUrl(newModel), _mapper.Map<T, TResponse>(newModel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] TRequest request)
        {
            var model = _mapper.Map<TRequest, T>(request);
            var updatedModel = await _service.Update(id, model);

            if (updatedModel == null) return BadRequest();

            return Ok(_mapper.Map<T, TResponse>(updatedModel));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Remove(id);

            return NoContent();
        }
    }
}