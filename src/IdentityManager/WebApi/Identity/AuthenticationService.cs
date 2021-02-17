using Docker.DotNet.Models;
using IdentityManager.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using AutoMapper;
using IdentityManager.WebApi.Models.Response;

namespace IdentityManager.API.Identity
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAgencyRepository _agencyRepository;

        public AuthenticationService(IUserRepository userRepository, IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository, IAgencyRepository agencyRepository)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _agencyRepository = agencyRepository;
        }
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

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> GetUserById(int id)
        {
            return Mapper.Map<UserResponseModel>(await _userRepository.FindeByIdAsync(id));
        }

        /// <summary>
        /// Get User by name
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> GetUserByUserName(string username)
        {
            return Mapper.Map<UserResponseModel>(await _userRepository.GetUserByUsernameAsync(username));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResponseModel>> GetUsers()
        {
            return Mapper.Map<IEnumerable<UserResponseModel>>(await _userRepository.GetAll());
        }

        /// <summary>
        /// Get agency by name
        /// </summary>
        /// <param name="agencyname"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> GetAgencyByName(string agencyname)
        {
            return Mapper.Map<AgencyResponseModel>(await _agencyRepository.GetAgencyByName(agencyname));

        }
        /// <summary>
        /// Get agency by name
        /// </summary>
        /// <param name="agencyname"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> GetAgencyById(int id)
        {
            return Mapper.Map<AgencyResponseModel>(await _agencyRepository.GetAgencyById(id));
        }


    }
}
