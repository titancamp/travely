using Docker.DotNet.Models;
using IdentityManager.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityManager.API.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        /// <summary>
        /// GenerateAccessToken
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> GenerateAccessToken(IdentityUser user)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GenerateAccessToken
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.AuthResponse> GenerateAccessToken(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// LoginUserAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.AuthResponse> LoginUserAsync(LoginViewModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ConfirmEmailAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<Models.AuthResponse> ConfirmEmailAsync(string userId, string token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ForgetPasswordAsync
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<Models.AuthResponse> ForgetPasswordAsync(string email)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ResetPasswordAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.AuthResponse> ResetPasswordAsync(ResetPasswordViewModel model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// RefreshToken
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<Models.AuthResponse> RefreshToken(Models.AuthResponse model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetUserFromAccessToken
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        private async Task<IdentityUser> GetUserFromAccessToken(string accessToken)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ValidateRefreshToken
        /// </summary>
        /// <param name="user"></param>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        private async Task<bool> ValidateRefreshToken(IdentityUser user, string refreshToken)
        {
            return false;
        }

        public Task<Models.AuthResponse> RegisterUserAsync(RegisterViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
