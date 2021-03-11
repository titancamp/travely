using IdentityManager.API.Models;
using IdentityManager.WebApi.Models;
using IdentityManager.WebApi.Models.Request;
using IdentityManager.WebApi.Models.Response;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using IdentityManager.WebApi.Models.Request;
using Microsoft.AspNetCore.JsonPatch;

namespace Travely.IdentityManager.WebApi.Identity
{
    public interface IAuthenticationService
    {
        Task RegisterUserAsync(RegisterRequestModel model, CancellationToken ct);
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
        Task <AgencyResponseModel> CreateAgency(AgencyRequestModel agencyRequestModel, CancellationToken ct = default);
    }
}
