using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using IdentityManager.WebApi.Models.Request;

namespace Travely.IdentityManager.API.Identity
{
    public interface IAuthenticationService
    {
        Task RegisterUserAsync(RegisterRequestModel model, CancellationToken ct);
        Task<ResultViewModel> ConfirmEmailAsync(string email, string token, CancellationToken ct);
        Task<ResultViewModel> ForgetPasswordAsync(string email, CancellationToken ct);
        Task<ResultViewModel> ResetPasswordAsync(ResetPasswordViewModel model, CancellationToken ct);
        Task<UserResponseModel> GetUserById(int id, CancellationToken ct);
        Task<IEnumerable<UserResponseModel>> GetUsers(CancellationToken ct);
        Task<AgencyResponseModel> GetAgencyById(int id, CancellationToken ct);
        Task<UserResponseModel> Create(UserRequestModel userRequestModel, CancellationToken ct);
        Task<UserResponseModel> Update(UserRequestModel userRequestModel, CancellationToken ct);
        Task DeleteUser(UserRequestModel userRequestModel, CancellationToken ct);
        Task <AgencyResponseModel> CreateAgency(AgencyRequestModel agencyRequestModel, CancellationToken ct);
    }
}
