using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityClient.Extensions;
using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models;
using Travely.IdentityManager.Service.Abstractions.Models.Error;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.WebApi.Extensions;

namespace Travely.IdentityManager.WebApi.Controllers
{
    [Route("api/account")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// RegisterAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<ValidationErrorModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequestModel model, CancellationToken ct = default)
        {
             await _authenticationService.RegisterUserAsync(model, ct);
            
            return Ok();
        }

        /// <summary>
        /// ConfirmEmail
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet("confirm")]
        public async Task<IActionResult> ConfirmEmail(string email, string token, CancellationToken ct = default)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return NotFound();
            var result = await _authenticationService.ConfirmEmailAsync(email, token, ct);

            return Ok(result);// TODO: refactor
        }

        /// <summary>
        /// ForgetPassword
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("password/forget")]
        [AllowAnonymous]
        public async Task<ActionResult<ResultViewModel>> ForgetPassword(ForgotPasswordViewModel forgotPasswordViewModel, CancellationToken cancellationToken = default)
        {
            if (!ModelState.IsValid)
                return NotFound();
            var result = await _authenticationService.ForgetPasswordAsync(forgotPasswordViewModel.Email, cancellationToken);

            return result;
        }

        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize]
        [HttpPost("password/reset")]
        public async Task<ActionResult<ResultViewModel>> ResetPassword([FromBody] ResetPasswordViewModel model, CancellationToken cancellationToken = default)
        {
            var userId = HttpContext.GetUserContext().UserId;

            return await _authenticationService.ResetPasswordAsync(model, userId, cancellationToken);
        }
    }
}
