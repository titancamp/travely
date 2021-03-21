﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.ServiceManager;
using TourManager.Common.Clients;

namespace TourManager.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ServiceController : Controller
    {
        private readonly IServiceManagerClient _serviceManagerClient;
        public ServiceController(IServiceManagerClient serviceManagerClient)
        {
            _serviceManagerClient = serviceManagerClient;
        }

        // GET api/<ServiceController>/5
        [HttpGet("{agencyId}")]
        public async Task<IEnumerable<Activity>> Get(long agencyId)
        {
            var result = await _serviceManagerClient.GetActivitiesAsync(agencyId);

            return result;
        }

        // POST api/<ServiceController>
        [HttpPost]
        public async Task<ActivityResponse> Post([FromBody] Activity activity)
        {
            var result = await _serviceManagerClient.CreateActivityAsync(activity);

            return result;
        }

        // PUT api/<ServiceController>
        [HttpPut]
        public async Task<ActivityResponse> Put([FromBody] Activity activity)
        {
            var result = await _serviceManagerClient.EditActivityAsync(activity);

            return result;
        }

        // DELETE api/<ServiceController>/5
        [HttpDelete("{id}")]
        public async Task<ActivityResponse> Delete(int id)
        {
            var result = await _serviceManagerClient.DeleteActivityAsync(id);

            return result;
        }

        // GET api/<ServiceController>/5/activitytype/cafe
        [HttpGet("{agencyId}/activitytype/{activityTypeName}")]
        public async Task<IEnumerable<ActivityType>> GetSearchedActivityTypes(long agencyId, string activityTypeName)
        {
            var result = await _serviceManagerClient.SearchActivityTypesAsync(agencyId, activityTypeName);

            return result;
        }
    }
}
