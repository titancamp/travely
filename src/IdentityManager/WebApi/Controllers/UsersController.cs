using IdentityManager.API.Identity;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper.Configuration;

namespace IdentityManager.WebApi.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public UsersController(IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _authenticationService = authenticationService;
            _configuration = configuration;
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<UserResponseModel>> GetUserByIdAsync(int id, CancellationToken ct)
        {
            return await _authenticationService.GetUserById(id, ct);
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponseModel>>> GetUsersAsync(CancellationToken ct)
        {
            return Ok(await _authenticationService.GetUsers(ct));
        }
    }
}
