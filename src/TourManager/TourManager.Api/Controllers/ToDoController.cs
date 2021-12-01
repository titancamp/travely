using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ReportingManager;
using TourManager.Service.Model.ReportingManager;
using Travely.IdentityClient.Authorization;

namespace TourManager.Api.Controllers
{
    [ApiVersion("1.0")]
    [Authorize(Roles = UserRoles.User)]
    public class ToDoController : TravelyControllerBase
    {
        private readonly IReportingManagerClient _reportingManagerClient;

        public ToDoController(IReportingManagerClient reportingManagerClient)
        {
            _reportingManagerClient = reportingManagerClient;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItemResponeModel>> Get(int id)
        {
            var data = await _reportingManagerClient.GetToDoItemAsync(id);

            return Ok(data);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoItemResponeModel>>> Get()
        {
            var data = await _reportingManagerClient.GetUserAllToDoItemsAsync(UserInfo.UserId);

            return Ok(data);
        }

        [HttpPost]
        public async Task<ToDoItemResponeModel> Post([FromBody] CreateToDoItemModel item)
        {
            var result = await _reportingManagerClient.CreateToDoItemAsync(item);

            return result;
        }

      
        [HttpPut]
        public async Task<ToDoItemResponeModel> Put([FromBody] CreateToDoItemModel item)
        {
            var result = await _reportingManagerClient.EditToDoItemAsync(item);

            return result;
        }

        
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var result = await _reportingManagerClient.DeleteToDoItemAsync(id);

            return result;
        }

    }
}
