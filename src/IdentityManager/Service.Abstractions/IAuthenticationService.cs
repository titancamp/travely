﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.JsonPatch;

using Travely.IdentityManager.Service.Abstractions.Models;
using Travely.IdentityManager.Service.Abstractions.Models.Request;
using Travely.IdentityManager.Service.Abstractions.Models.Response;

namespace Travely.IdentityManager.Service.Abstractions
{
    public interface IAuthenticationService
    {
        Task<ResultViewModel> RegisterUserAsync(RegisterRequestModel model, CancellationToken ct);
        Task<ResultViewModel> ConfirmEmailAsync(string email, string token, CancellationToken ct = default);
        Task<ResultViewModel> ForgetPasswordAsync(string email, CancellationToken ct = default);
        Task<ResultViewModel> ResetPasswordAsync(ResetPasswordViewModel model, CancellationToken ct = default);
        Task<UserResponseModel> GetUserById(int id, CancellationToken ct = default);
        Task<List<UserResponseModel>> GetUsers(CancellationToken ct = default);
        Task<AgencyResponseModel> GetAgencyById(int id, CancellationToken ct = default);
        Task UpdateAccountAsync(UserContextModel userContext, JsonPatchDocument<UpdateAgencyRequestModel> jsonPatch, CancellationToken ct);
        Task<UserResponseModel> Create(UserRequestModel userRequestModel, CancellationToken ct = default);
        Task<UserResponseModel> Update(UserRequestModel userRequestModel, CancellationToken ct = default);
        Task DeleteUser(int id, CancellationToken ct = default);
        Task<AgencyResponseModel> CreateAgency(AgencyRequestModel agencyRequestModel, CancellationToken ct = default);
    }
}
