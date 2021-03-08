using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models;
using Travely.IdentityManager.API.Identity;
using IdentityManager.WebApi.Models.Request;
using Microsoft.AspNetCore.Http;
using IdentityManager.WebApi.Models.Error;
using System.Collections.Generic;
using Microsoft.AspNetCore.JsonPatch;
using IdentityManager.WebApi.Extensions;

namespace Travely.IdentityManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    //[ApiController]
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
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
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
        [HttpGet("ConfirmEmail")]
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
        [HttpPost("ForgetPassword")]
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
        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ResultViewModel>> ResetPassword([FromBody] ResetPasswordViewModel model, CancellationToken cancellationToken = default)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.ResetPasswordAsync(model, cancellationToken);

                return result;
            }

            return BadRequest("Some properties are not valid");
        }

        [HttpPatch()]
        [Authorize]
        public async Task UpdateAccountAsync([FromBody] JsonPatchDocument<UpdateAgencyRequestModel> agencyPatch, CancellationToken cancellationToken = default)
        {
            await _authenticationService.UpdateAccountAsync(HttpContext.GetUserContext(), agencyPatch, cancellationToken);
        }

        ///// <summary>
        ///// Get agency by agency id
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
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
