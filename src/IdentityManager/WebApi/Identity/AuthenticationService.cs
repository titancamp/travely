using IdentityManager.API.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using IdentityManager.WebApi.Models.Response;
using Travely.IdentityManager.Repository.Abstractions;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutoMapper;
using IdentityManager.WebApi.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IdentityManager.WebApi.Models;
using Microsoft.AspNetCore.WebUtilities;

namespace IdentityManager.API.Identity
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAgencyRepository _agencyRepository;

        public AuthenticationService(UserManager<IdentityUser> userManager, IUserRepository userRepository, IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository, IAgencyRepository agencyRepository, IMapper mapper) : base(mapper)
        {
            _userManager = userManager;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _agencyRepository = agencyRepository;
        }

        /// <summary>
        /// ConfirmEmailAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResultViewModel>> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                return new ResultViewModel
                {
                    IsSuccess = false,
                    Message = "User not found"
                };

            var decodedToken = WebEncoders.Base64UrlDecode(token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ConfirmEmailAsync(user, normalToken);

            if (result.Succeeded)
                return new ResultViewModel()
                {
                    Message = "Email confirmed successfully!",
                    IsSuccess = true,
                };

            return new ResultViewModel
            {
                IsSuccess = false,
                Message = "Email did not confirm",
                Errors = result.Errors.Select(e => e.Description)
            };
        }

        /// <summary>
        /// ForgetPasswordAsync
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResultViewModel>> ForgetPasswordAsync(string email, CancellationToken ct)
        {
            var user = await _userRepository.FindByEmailAsync(email, ct);
            if (user == null)
                return new ResultViewModel
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };
            return new ResultViewModel
            {
                IsSuccess = true,
                Message = "Reset password URL has been sent to the email successfully!"
            };
        }

        /// <summary>
        /// ResetPasswordAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ActionResult<ResultViewModel>> ResetPasswordAsync(ResetPasswordViewModel model, CancellationToken ct)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
                return new ResultViewModel
                {
                    IsSuccess = false,
                    Message = "No user associated with email",
                };

            if (model.NewPassword != model.ConfirmPassword)
                return new ResultViewModel
                {
                    IsSuccess = false,
                    Message = "Password doesn't match its confirmation",
                };

            var decodedToken = WebEncoders.Base64UrlDecode(model.Token);
            string normalToken = Encoding.UTF8.GetString(decodedToken);

            var result = await _userManager.ResetPasswordAsync(user, normalToken, model.NewPassword);

            if (result.Succeeded)
                return new ResultViewModel()
                {
                    Message = "Password has been reset successfully!",
                    IsSuccess = true,
                };

            return new ResultViewModel
            {
                Message = "Something went wrong",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description),
            };
        }

        public async Task<ActionResult<ResultViewModel>> RegisterUserAsync(RegisterViewModel model, CancellationToken ct)
        {
            if (model == null)
                throw new NullReferenceException("Reigster Model is null");

            if (model.Password != model.ConfirmPassword)
                return new ResultViewModel
                {
                    Message = "Confirm password doesn't match the password",
                    IsSuccess = false,
                };
            var user = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.Email,
                CreatedDate = DateTime.UtcNow
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var refreshToken = await _userManager.GenerateConcurrencyStampAsync(user);
                _unitOfWork.SaveChangesAsync(ct);

                return new ResultViewModel
                {
                    Message = "User created successfully!",
                    IsSuccess = true,
                };
            }
            return new ResultViewModel
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> GetUserById(int id, CancellationToken ct)
        {
            return Mapper.Map<UserResponseModel>(await _userRepository.FindByIdAsync(id, ct));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<UserResponseModel>> GetUsers(CancellationToken ct)
        {
            return Mapper.Map<IEnumerable<UserResponseModel>>(await _userRepository.GetAll().ToListAsync());
        }

        /// <summary>
        /// Get agency by name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> GetAgencyById(int id, CancellationToken ct)
        {
            return Mapper.Map<AgencyResponseModel>(await _agencyRepository.FindByIdAsync(id, ct));
        }

    }
}
