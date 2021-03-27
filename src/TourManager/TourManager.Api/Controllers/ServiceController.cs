using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Common.Clients;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Travely.IdentityClient.Authorization;

namespace TourManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly IServiceManagerClient _serviceManagerClient;
        private readonly long _agencyId;
        public ServiceController(IServiceManagerClient serviceManagerClient)
        {
            _serviceManagerClient = serviceManagerClient;
            var userInfo = HttpContext.GetTravelyUserInfo();
            if (userInfo is not null) { _agencyId = userInfo.AgencyId; }
        }

        // GET api/<ServiceController>
        [HttpGet]
        public async Task<IEnumerable<Activity>> Get()
        {
            var result = await _serviceManagerClient.GetActivitiesAsync(_agencyId);

            return result;
        }

        // POST api/<ServiceController>
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActivityResponse> Post([FromBody] Activity activity)
        {
            if (activity.Type != null) { activity.Type.AgencyId = _agencyId; }

            var result = await _serviceManagerClient.CreateActivityAsync(activity);

            return result;
        }

        // PUT api/<ServiceController>
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActivityResponse> Put([FromBody] Activity activity)
        {
            if (activity.Type != null) { activity.Type.AgencyId = _agencyId; }

            var result = await _serviceManagerClient.EditActivityAsync(activity);

            return result;
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<ActivityResponse> Delete(int id)
        {
            var result = await _serviceManagerClient.DeleteActivityAsync(id);

            return result;
        }

        // GET api/<ServiceController>/activitytype/cafe
        [HttpGet("activitytype/{activityTypeName}")]
        public async Task<IEnumerable<ActivityType>> GetSearchedActivityTypes(string activityTypeName)
        {
            var result = await _serviceManagerClient.SearchActivityTypesAsync(_agencyId, activityTypeName);

            return result;
        }
    }
}
