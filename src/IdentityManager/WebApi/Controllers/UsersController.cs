using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travely.Common.Entities;
using Travely.IdentityClient.Authorization;
using Travely.IdentityClient.Extensions;
using Travely.IdentityManager.Repository.Abstractions.Entities;
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

        ///  <summary>
        ///  Set user password
        ///  </summary>
        ///  <param name="setPasswordRequestModel"></param>
        ///  <param name="cancellationToken"></param>
        ///  <returns></returns>
        /// [Authorize]   //eMail and agencyId will be taken from token
        [HttpPut("setpassword")]
        public async Task<IActionResult> SetPasswordAsync([FromBody]SetPasswordRequestModel setPasswordRequestModel, CancellationToken cancellationToken = default)
        {
            await _authenticationService.SetPasswordAsync(setPasswordRequestModel.Email
                                                        , setPasswordRequestModel.Password
                                                        , setPasswordRequestModel.AgencyId
                                                        , cancellationToken);
            return NoContent();
        }
        
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Permission(Permission.Admin)]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponseModel>> GetUserByIdAsync([FromRoute]int id, CancellationToken cancellationToken = default)
        {
            return await _authenticationService.GetUserById(id, cancellationToken);
        }

        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("current")]
        public async Task<ActionResult<UserResponseModel>> GetCurrentUserAsync(CancellationToken cancellationToken = default)
        {
            var id = HttpContext.GetUserContext().UserId;
            return await _authenticationService.GetUserById(id, cancellationToken);
        }

        /// <summary>
        /// Get current user
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPut("current")]
        public Task<ActionResult<UserResponseModel>> EditCurrentUserAsync([FromBody] UserRequestModel userRequestModel, CancellationToken cancellationToken = default)
        {
            var id = HttpContext.GetUserContext().UserId;
            return EditUserAsync(id, userRequestModel, cancellationToken);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Permission(Permission.Admin)]
        [HttpPut("all")]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync([FromBody] bool includeDeleted = false, CancellationToken cancellationToken = default)
        {
            var agencyId = HttpContext.GetUserContext().AgencyId;
            return await _authenticationService.GetUsersAsync(agencyId, includeDeleted, cancellationToken);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userResponseModel"></param>
        /// <returns></returns>
        [Authorize]
        [Permission(Permission.Admin)]
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
        [Authorize]
        [Permission(Permission.Admin)]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserResponseModel>> EditUserAsync([FromRoute]int id, [FromBody] UserRequestModel userRequestModel, CancellationToken cancellationToken = default)
        {
            try
            {
                var agencyId = HttpContext.GetUserContext().AgencyId;
                userRequestModel.Id = id;
                return await _authenticationService.UpdateUserAsync(userRequestModel, agencyId, cancellationToken);
            }
            catch (UserNotFoundException)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Permission(Permission.Admin)]
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
                await _authenticationService.ChangeUserStatusAsync(id, agencyId, Status.Deleted, cancellationToken);
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
        
        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize]
        [Permission(Permission.Admin)]
        [HttpPut("reactivate/{id}")]
        public async Task<IActionResult> ReActivateUserAsync([FromRoute] int id, CancellationToken cancellationToken)
        {
            var userContext = HttpContext.GetUserContext();
            if (userContext.UserId == id)
            {
                return BadRequest("Shooting yourself in the leg is not allowed.");
            }

            var agencyId = userContext.AgencyId;
            try
            {
                await _authenticationService.ChangeUserStatusAsync(id, agencyId, Status.Active, cancellationToken);
            }
            catch(UserNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
