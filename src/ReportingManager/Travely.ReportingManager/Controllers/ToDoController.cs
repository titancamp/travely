using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.Common;
using Travely.Common.Api.Controllers;
using Travely.ReportingManager.Grpc.Client.Abstraction;
using Travely.ReportingManager.Grpc.Models;
using Travely.Shared.IdentityClient.Authorization.Common;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
    //[Authorize(Roles = UserRoles.User)]
    public class ToDoController : TravelyControllerBase
    {
        private readonly IReportingManagerClient _service;

        public ToDoController(IReportingManagerClient service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemResponeModel>> Get(int id)
        {
            var data = await _service.GetByIdAsync(id);

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateToDoModel model)
        {
            var id = await _service.AddToDoItemAsync(UserInfo.UserId, model);

            return Created("url",id);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateToDoModel model)
        {
            var id = await _service.EditToDoItemAsync(UserInfo.UserId, model.Id, model);

            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteToDoItemAsync(id);

            return NoContent();
        }

        [HttpPost("List")]
        public async Task<ActionResult<IEnumerable<ToDoItemResponeModel>>> List([FromBody] DataQueryModel dataQueryModel)
        {
            if (dataQueryModel.Paging==null || dataQueryModel.Paging.Count==0)
            {
                return NoContent();
            }
            var data=await _service.GetToDoItemsAsync(UserInfo.UserId, dataQueryModel);
            return Ok(data);
        }

    }
}
