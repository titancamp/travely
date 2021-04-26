using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.Service.Abstractions.Models.Response;

using Travely.IdentityManager.WebApi.Extensions;

namespace Travely.IdentityManager.WebApi.Controllers
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
            return await _authenticationService.GetAgencyByIdAsync(agencyId, cancellationToken);
        }

    }
}
