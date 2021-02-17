using Docker.DotNet.Models;
using IdentityManager.API.Identity;
using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AccountController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }

        /// <summary>
        /// RegisterAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.RegisterUserAsync(model);
                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }
        /// <summary>
        /// LoginAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        /// <summary>
        /// ConfirmEmail
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return NotFound();

            var result = await _authenticationService.ConfirmEmailAsync(email, token);

            if (result.IsSuccess)
            {
                return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
            }

            return BadRequest(result);
        }

        /// <summary>
        /// ForgetPassword
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return NotFound();

            var result = await _authenticationService.ForgetPasswordAsync(email);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.ResetPasswordAsync(model);

                if (result.IsSuccess)
                    return Ok(result);

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

        /// <summary>
        /// Get user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<UserResponseModel>> GetUserByUserNameAsync(string username)
        {
            return Ok(await _authenticationService.GetUserByUserName(username));
        }

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<UserResponseModel>> GetUserByIdAsync(int id)
        {
            return Ok(await _authenticationService.GetUserById(id));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync()
        {
            return Ok(await _authenticationService.GetUsers());
        }

        /// <summary>
        /// Get agency by agency name
        /// </summary>
        /// <param name="agencyName"></param>
        /// <returns></returns>
        public async Task<ActionResult<AgencyResponseModel>> GetAgencyByNameAsync(string agencyName)
        {
            return Ok(await _authenticationService.GetAgencyByName(agencyName));
        }

        /// <summary>
        /// Get agency by agency id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<AgencyResponseModel>> GetAgencyByIdAsync(int id)
        {
            return Ok(await _authenticationService.GetAgencyById(id));
        }

    }
}
