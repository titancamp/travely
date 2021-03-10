using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models;
using Travely.IdentityManager.WebApi.Identity;
using IdentityManager.WebApi.Models.Request;

namespace Travely.IdentityManager.WebApi.Controllers
{
    [Route("api/account")]
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
        [HttpPost("register")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ResultViewModel>> RegisterAsync([FromBody] RegisterViewModel model, CancellationToken ct = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.RegisterUserAsync(model, ct);

                return result;
            }
            return BadRequest("Some properties are not valid");

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

            return Redirect($"{_configuration["AppUrl"]}/ConfirmEmail.html");
        }

        /// <summary>
        /// ForgetPassword
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpPost("password/forget")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
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
        [HttpPost("password/reset")]
        public async Task<ActionResult<ResultViewModel>> ResetPassword([FromBody] ResetPasswordViewModel model, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.ResetPasswordAsync(model, cancellationToken);

                return result;
            }

            return BadRequest("Some properties are not valid");
        }

        ///// <summary>
        ///// Get agency by agency id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult<AgencyResponseModel>> GetAgencyByIdAsync(int id, CancellationToken cancellationToken = default)
        //{
        //    return await _authenticationService.GetAgencyById(id, cancellationToken);
        //}

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
