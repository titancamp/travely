using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Grpc.Net.Client;
using IdentityManager.Service.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using Travely.Common.Entities;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Service.Abstractions;
using Travely.IdentityManager.Service.Abstractions.Models;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.Service.Abstractions.Models.Response;

namespace Travely.IdentityManager.Service.Identity
{
    public class AuthenticationService : BaseService, IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passHasher;

        public AuthenticationService(IUserRepository userRepository, IUnitOfWork unitOfWork, IAgencyRepository agencyRepository, IMapper mapper, IPasswordHasher<User> passHasher) : base(mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
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

        public async Task<ResultViewModel> RegisterUserAsync(RegisterRequestModel model, CancellationToken ct = default)
        {
            User user = _mapper.Map<User>(model);
            _userRepository.Add(user);
            user.Agency.CreatedBy = user.Id;

            user.Agency = user.Agency;
            _agencyRepository.Add(user.Agency);

            await _unitOfWork.SaveChangesAsync(ct);
            return new ResultViewModel();
        }

        /// <summary>
        /// Get User by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> GetUserById(int id, CancellationToken ct = default)
        {
            return _mapper.Map<UserResponseModel>(await _userRepository.GetAll().FirstOrDefaultAsync(x=>x.Id == id, ct));
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public Task<List<UserResponseModel>> GetUsersAsync(int agencyId, bool includeDeleted = false, CancellationToken ct = default)
        {
            return _mapper.ProjectTo<UserResponseModel>(_userRepository.GetAll()
                .Where(x => x.AgencyId == agencyId && (includeDeleted || x.Status != Status.Deleted)))
                .ToListAsync(cancellationToken: ct);
        }

        /// <summary>
        /// Get agency by name
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<AgencyResponseModel> GetAgencyByIdAsync(int id, CancellationToken ct = default)
        {
            return _mapper.Map<AgencyResponseModel>(await _agencyRepository.FindByIdAsync(id, ct));
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userResponseModel"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task<UserResponseModel> CreateAsync(UserRequestModel userRequestModel, int agencyId, CancellationToken ct = default)
        {
            Agency agency = await _agencyRepository.FindAsync(x => x.Id == agencyId, ct);
            if (agency is null)
            {
                throw new IdentityException("Invalid Agency.");
            }
            User user = await _userRepository.FindAsync(x => x.UserName == userRequestModel.Email, ct);
            if (user != null)
            {
                throw new IdentityException("This email already registered.");
            }
            user = _mapper.Map<User>(userRequestModel);
            user.Password = string.Empty;
            user.Agency = agency;
            user.Status = Status.Inactive;
            
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
        public async Task<UserResponseModel> UpdateUserAsync(UserRequestModel userRequestModel, int agencyId, CancellationToken ct = default)
        {
            User user = await _userRepository.GetAll()
                .Where(x => x.Id == userRequestModel.Id && x.AgencyId == agencyId)
                .FirstOrDefaultAsync(ct);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            user = _mapper.Map(userRequestModel, user);

            _userRepository.Update(user);

            await _unitOfWork.SaveChangesAsync(ct);
            var data = _mapper.Map<UserResponseModel>(user);
            return data;
        }

        /// <summary>
        /// Change user status
        /// </summary>
        /// <param name="id"></param>
        /// <param name="agencyId"></param>
        /// <param name="status"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        public async Task ChangeUserStatusAsync(int id, int agencyId, Status status, CancellationToken ct = default)
        {
            if (status == Status.Inactive)
            {
                throw new InvalidOperationException();
            }
            var user = await _userRepository.GetAll()
                .Where(x => x.Id == id && x.AgencyId == agencyId && x.Permissions != Permission.Admin && x.Status != Status.Inactive)
                .FirstOrDefaultAsync(ct);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.Status = status;
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(ct);
        }

        public async Task UpdateAccountAsync(int agencyId, UpdateAgencyRequestModel model, CancellationToken ct = default)
        {
            Agency agency = await _agencyRepository.FindByIdAsync(agencyId, ct);
            _mapper.Map(model, agency);
            _agencyRepository.Update(agency);

            await _unitOfWork.SaveChangesAsync(ct);
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
            _userRepository.Add(user);
            await _unitOfWork.SaveChangesAsync(ct);
            return data;
        }

        ///  <summary>
        ///  Set user password
        ///  </summary>
        ///  <param name="eMail"></param>
        ///  <param name="password"></param>
        ///  <param name="agencyId"></param>
        ///  <returns></returns>
        public async Task SetPasswordAsync(string eMail, string password, int agencyId, CancellationToken ct = default)
        {
            var user = await _userRepository.GetAll()
                .Where(x => x.Email == eMail && x.AgencyId == agencyId && x.Status == Status.Inactive)
                .FirstOrDefaultAsync(ct);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            user.Status = Status.Active;
            user.Password = _passHasher.HashPassword(user, password);
            _userRepository.Update(user);
            await _unitOfWork.SaveChangesAsync(ct);        }
    }
}
