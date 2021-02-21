using System;
using IdentityManager.API.Identity;
using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models;
using IdentityModel;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace IdentityManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IAuthenticationService authenticationService,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<ResultViewModel>> RegisterAsync([FromBody] RegisterViewModel model, CancellationToken ct)
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
        [HttpGet("ConfirmEmail")]
        public async Task<ActionResult> ConfirmEmail(string email, string token)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(token))
                return NotFound();
            var result = await _authenticationService.ConfirmEmailAsync(email, token);

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
        public async Task<ActionResult<ResultViewModel>> ForgetPassword(ForgotPasswordViewModel forgotPasswordViewModel, CancellationToken ct)
        {
            if (!ModelState.IsValid)
                return NotFound();

            var result = await _authenticationService.ForgetPasswordAsync(forgotPasswordViewModel.Email, ct);
            return result;
        }

        /// <summary>
        /// ResetPassword
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        public async Task<ActionResult<ResultViewModel>> ResetPassword([FromBody] ResetPasswordViewModel model, CancellationToken ct)
        {
            if (ModelState.IsValid)
            {
                var result = await _authenticationService.ResetPasswordAsync(model, ct);
                return result;
            }

            return BadRequest("Some properties are not valid");
        }

        /// <summary>
        /// Get agency by agency id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<AgencyResponseModel>> GetAgencyByIdAsync(int id, CancellationToken ct)
        {
            return await _authenticationService.GetAgencyById(id, ct);
        }

    }
}
