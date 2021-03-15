using AutoMapper.Configuration;
using IdentityManager.WebApi.Extensions;
using IdentityManager.WebApi.Models.Request;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.WebApi.Identity;

namespace IdentityManager.WebApi.Controllers
{
    [Route("api/agency")]
    [Produces("application/json")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AgencyController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpPatch]
        [Authorize]
        public async Task UpdateAccountAsync([FromBody] JsonPatchDocument<UpdateAgencyRequestModel> agencyPatch, CancellationToken cancellationToken = default)
        {
            //TODO: validate agencyId, if it is match current UserId
            await _authenticationService.UpdateAccountAsync(HttpContext.GetUserContext(), agencyPatch, cancellationToken);
        }

        /// <summary>
        /// Get agency by agency id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AgencyResponseModel>> GetAgencyByIdAsync(CancellationToken cancellationToken = default)
        {
            var agencyId = HttpContext.GetUserContext().AgencyId;
            return await _authenticationService.GetAgencyById(agencyId, cancellationToken);
        }

        ///// <summary>
        ///// Add Agency
        ///// </summary>
        ///// <param name="agencyRequestModel"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns></returns>
        //public async Task<ActionResult<AgencyResponseModel>> CreateAgencyAsync(AgencyRequestModel agencyRequestModel, CancellationToken cancellationToken = default)
        //{
        //    return await _authenticationService.CreateAgency(agencyRequestModel, cancellationToken);
        //}
    }
}
