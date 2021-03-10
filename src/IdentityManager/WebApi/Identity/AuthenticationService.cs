using AutoMapper;
using IdentityManager.API.Models;
using IdentityManager.WebApi.Models;
using IdentityManager.WebApi.Models.Request;
using IdentityManager.WebApi.Models.Response;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using IdentityManager.WebApi.Models.Request;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using System.Linq;
using Travely.IdentityManager.WebApi.Identity;

namespace Travely.IdentityManager.API.Identity
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passHasher;

        public AuthenticationService(IUserRepository userRepository, IUnitOfWork unitOfWork,
            IEmployeeRepository employeeRepository, IAgencyRepository agencyRepository, IMapper mapper, IPasswordHasher<User> passHasher) : base(mapper)
        {

            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _employeeRepository = employeeRepository;
            _agencyRepository = agencyRepository;
            _mapper = mapper;
            _passHasher = passHasher;
        }

        /// <summary>
        /// ConfirmEmailAsync
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<ResultViewModel> ConfirmEmailAsync(string userId, string token, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ForgetPasswordAsync
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public async Task<ResultViewModel> ForgetPasswordAsync(string email, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// ResetPasswordAsync
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ResultViewModel> ResetPasswordAsync(ResetPasswordViewModel model, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(RegisterRequestModel model, CancellationToken ct)
        {
            User user = _mapper.Map<User>(model);
            _userRepository.Add(user);
            user.Agency.Owner = user;

            user.Employee.Agency = user.Agency;
            _agencyRepository.Add(user.Agency);



            await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> GetUserById(int id, CancellationToken ct = default)
        {
            return _mapper.Map<UserResponseModel>(await _userRepository.FindByIdAsync(id, ct));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public async Task<List<UserResponseModel>> GetUsers(CancellationToken ct = default)
        {
            return await _mapper.ProjectTo<UserResponseModel>(_userRepository.GetAll().Include(x=>x.Employee)).ToListAsync();

        }

        /// <summary>
        /// Get agency by name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> GetAgencyById(int id, CancellationToken ct = default)
        {
            return _mapper.Map<AgencyResponseModel>(await _agencyRepository.FindByIdAsync(id, ct));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userResponseModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> Create(UserRequestModel userRequestModel, CancellationToken ct = default)
        {
            int agencyId = 1;// this value cames by parameter, from token claims
            Agency agency = await _agencyRepository.FindAsync(x => x.Id == agencyId);
            if (agency is null)
            {
                // report agency doesn't exist
            }
            User user = await _userRepository.FindAsync(x => x.UserName == userRequestModel.Email);
            if (user != null)
            {
                // report user with this email exists
            }
            user = _mapper.Map<User>(userRequestModel);
            user.Agency = agency;
            user.Employee.Agency = user.Agency;
            
            _userRepository.Add(user);

            await _unitOfWork.SaveChangesAsync(ct);
            var data = _mapper.Map<UserResponseModel>(user);
            return data;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userRequestModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> Update(UserRequestModel userRequestModel, CancellationToken ct = default)
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
        public async Task DeleteUser(int id, CancellationToken ct = default)
        {
            var entity = await _userRepository.FindByIdAsync(id, ct);
            _userRepository.Remove(entity);
            await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task UpdateAccountAsync(UserContextModel userContext, JsonPatchDocument<UpdateAgencyRequestModel> jsonPatch, CancellationToken ct)
        {
            Agency agency = await _agencyRepository.GetAll().Where(x => x.Id == userContext.AgencyId).Include
                (x => x.Employees).FirstOrDefaultAsync();

            UpdateAgencyRequestModel jsonPatchDTO = _mapper.Map<UpdateAgencyRequestModel>(agency);

            jsonPatch.ApplyTo(jsonPatchDTO);

            _mapper.Map(jsonPatchDTO, agency);

            _agencyRepository.Update(agency);

            await _unitOfWork.SaveChangesAsync();

            //return jsonPatchDTO;
        }

        /// <summary>
        /// Create Agency
        /// </summary>
        /// <param name="agencyRequestModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> CreateAgency(AgencyRequestModel agencyRequestModel, CancellationToken ct = default)
        {
            var entity = _mapper.Map<Agency>(agencyRequestModel);
            var data = _mapper.Map<AgencyResponseModel>(_agencyRepository.Add(entity));
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
