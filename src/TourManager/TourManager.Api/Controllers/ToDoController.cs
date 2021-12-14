using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ReportingManager;
using TourManager.Service.Abstraction;
using TourManager.Service.Model.ReportingManager;
using Travely.IdentityClient.Authorization;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
   // [Authorize(Roles = UserRoles.User)]
    public class ToDoController : TravelyControllerBase
    {
        private readonly IToDoService _service;

        public ToDoController(IToDoService service)
        {
            _service = service;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemResponeModel>> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemResponeModel>>> Get()
        {
            var data = await _service.GetAsync(UserInfo.UserId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateToDoModel model)
        {
            var id = await _service.AddAsync(UserInfo.UserId, model);

            return Created("url",id);
        }

      
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateToDoModel model)
        {
            var id = await _service.EditAsync(UserInfo.UserId, model.Id, model);

            return Ok(id);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            return NoContent();
        }

    }
}
