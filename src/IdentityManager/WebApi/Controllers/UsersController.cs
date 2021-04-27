using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.Service.Abstractions.Models.Response;
using Travely.IdentityManager.Service.Identity;
using Travely.IdentityManager.WebApi.Extensions;

namespace Travely.IdentityManager.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public UsersController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseModel>> GetUserByIdAsync([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            return await _authenticationService.GetUserById(id, cancellationToken);
        }
        
        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns></returns>
        [Authorize()]
        [HttpGet("current")]
        public async Task<ActionResult<UserResponseModel>> GetCurrentUserAsync(CancellationToken cancellationToken = default)
        {
            var id = HttpContext.GetUserContext().UserId;
            return await _authenticationService.GetUserById(id, cancellationToken);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            var agencyId = HttpContext.GetUserContext().AgencyId;
            return await _authenticationService.GetUsersAsync(agencyId, cancellationToken);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userResponseModel"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<ActionResult<UserResponseModel>> CreateUserAsync([FromBody] UserRequestModel userResponseModel, CancellationToken cancellationToken = default)
        {
            try
            {
                var agencyId = HttpContext.GetUserContext().AgencyId;
                return await _authenticationService.CreateAsync(userResponseModel, agencyId, cancellationToken);
            }
            catch(IdentityException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        /// <summary>
        /// Update User 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseModel>> EditAsync([FromRoute]int id, [FromBody] UpdateUserRequestModel userRequestModel, CancellationToken cancellationToken = default)
        {
            var agencyId = HttpContext.GetUserContext().AgencyId;
            userRequestModel.Id = id;
            return await _authenticationService.UpdateAsync(userRequestModel, agencyId, cancellationToken);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var userContext = HttpContext.GetUserContext();
            if (userContext.UserId == id)
            {
                return BadRequest("Shooting yourself in the leg is not allowed.");
            }

            var agencyId = userContext.AgencyId;
            try
            {
                await _authenticationService.DeleteUserAsync(id, agencyId, cancellationToken);
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
