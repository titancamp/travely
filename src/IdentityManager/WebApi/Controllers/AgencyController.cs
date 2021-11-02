using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
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

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateAccountAsync([FromBody] UpdateAgencyRequestModel agency, CancellationToken ct = default)
        {
            var agencyId = HttpContext.GetUserContext().AgencyId;
            await _authenticationService.UpdateAccountAsync(agencyId, agency, ct);
            return NoContent();
        }

        /// <summary>
        /// Get agency by agency id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<AgencyResponseModel>> GetAgencyAsync(CancellationToken ct = default)
        {
            var agencyId = HttpContext.GetUserContext().AgencyId;
            return await _authenticationService.GetAgencyByIdAsync(agencyId, ct);
        }

    }
}
