using IdentityManager.API.Models;
using System;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models.Response;
using Travely.IdentityManager.Repository.Abstractions;
using System.Collections.Generic;
using System.Threading;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using IdentityManager.WebApi.Models;
using Travely.IdentityManager.API.Identity;
using Travely.IdentityManager.WebApi.Identity;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using IdentityManager.WebApi.Models.Request;


namespace Travely.IdentityManager.WebApi.Controllers
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public AuthenticationService( IUserRepository userRepository, IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository, IAgencyRepository agencyRepository, IMapper mapper) : base(mapper)
        {

            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// ConfirmEmailAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ResultViewModel> ConfirmEmailAsync(string userId, string token, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ForgetPasswordAsync
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<ResultViewModel> ForgetPasswordAsync(string email, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ResetPasswordAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultViewModel> ResetPasswordAsync(ResetPasswordViewModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultViewModel> RegisterUserAsync(RegisterViewModel model, CancellationToken ct)
        {
            throw new NotImplementedException();
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
            return await _mapper.ProjectTo<UserResponseModel>(_userRepository.GetAll()).ToListAsync(); ;

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

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userResponseModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> Create(UserRequestModel userRequestModel, CancellationToken ct)
        {
            var entity = Mapper.Map<User>(userRequestModel);
            var data = Mapper.Map<UserResponseModel>(_userRepository.Add(entity));
            await _unitOfWork.SaveChangesAsync(ct);
            return data;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> Update(UserRequestModel userRequestModel, CancellationToken ct)
        {
            var entity = Mapper.Map<User>(userRequestModel);
            var data = Mapper.Map<UserResponseModel>(_userRepository.Update(entity));
            await _unitOfWork.SaveChangesAsync(ct);
            return data;
        }

        /// <summary>
        /// DeleteUser
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task DeleteUser(UserRequestModel userRequestModel, CancellationToken ct)
        {
            var entity = Mapper.Map<User>(userRequestModel);
            _userRepository.Remove(entity);
        }

        /// <summary>
        /// Create Agency
        /// </summary>
        /// <param name="agencyRequestModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> CreateAgency(AgencyRequestModel agencyRequestModel, CancellationToken ct)
        {
            var entity = Mapper.Map<Agency>(agencyRequestModel);
            var data = Mapper.Map<AgencyResponseModel>(_agencyRepository.Add(entity));
            var user = new User
            {
                Agency = entity
            };
            var employe = new Employee
            {
                User = user
            };
            _employeeRepository.Add(employe);
            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync(ct);
            return data;

        }

    }
}
