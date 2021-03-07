using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.API.Identity;
using IdentityManager.WebApi.Models.Request;

namespace Travely.IdentityManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
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
        public async Task<ActionResult<UserResponseModel>> GetUserByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await _authenticationService.GetUserById(id, cancellationToken);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IEnumerable<UserResponseModel>> GetUsersAsync(CancellationToken cancellationToken = default)
        {
            return await _authenticationService.GetUsers(cancellationToken);
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
            return await _authenticationService.Create(userResponseModel, cancellationToken);
        }
        /// <summary>
        /// Update User 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id:int:min(1)}")]
        public async Task<ActionResult<UserResponseModel>> EditAsync(int id, [FromBody] UserRequestModel userRequestModel, CancellationToken cancellationToken = default)
        {
            var entityForValidation = await _authenticationService.GetUserById(id, cancellationToken);
            if (entityForValidation == null)
            {
                return NotFound();
            }
            userRequestModel.Id = id;
            return await _authenticationService.Update(userRequestModel, cancellationToken);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int:min(1)}")]
        public async Task DeleteUserAsync(UserRequestModel userRequestModel, CancellationToken cancellationToken)
        {
            var entityForValidation = await _authenticationService.GetUserById(userRequestModel.Id, cancellationToken);
            if (entityForValidation == null)
            {
                 NotFound();
            }
             await _authenticationService.DeleteUser(userRequestModel, cancellationToken);

        }

    }
}
