using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.JsonPatch;
using Travely.IdentityManager.Repository.Abstractions.Entities;
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
        Task<List<UserResponseModel>> GetUsersAsync(int agencyId, bool includeDeleted = false, CancellationToken ct = default);
        Task<AgencyResponseModel> GetAgencyByIdAsync(int id, CancellationToken ct = default);
        Task UpdateAccountAsync(int id, UpdateAgencyRequestModel model, CancellationToken ct = default);
        Task<UserResponseModel> CreateAsync(UserRequestModel userRequestModel, int agencyId, CancellationToken ct = default);
        Task<UserResponseModel> UpdateUserAsync(UserRequestModel userRequestModel, int agencyId, CancellationToken ct = default);
        Task ChangeUserStatusAsync(int id, int agencyId, Status status, CancellationToken ct = default);
        Task SetPasswordAsync(string  eMail, string password, int agencyId, CancellationToken ct = default);
    }
}
