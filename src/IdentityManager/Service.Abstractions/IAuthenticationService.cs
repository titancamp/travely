using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
        Task<List<UserResponseModel>> GetUsersAsync(int agencyId, CancellationToken ct = default);
        Task<AgencyResponseModel> GetAgencyByIdAsync(int id, CancellationToken ct = default);
        Task UpdateAccountAsync(int id, UpdateAgencyRequestModel model, CancellationToken ct = default);
        Task<UserResponseModel> CreateAsync(UserRequestModel userRequestModel, int agencyId, CancellationToken ct = default);
        Task<UserResponseModel> UpdateUserAsync(UpdateUserRequestModel userRequestModel, int agencyId, CancellationToken ct = default);
        Task DeleteUserAsync(int id, int agencyId, CancellationToken ct = default);
    }
}
