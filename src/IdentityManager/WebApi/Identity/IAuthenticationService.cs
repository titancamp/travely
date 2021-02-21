using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using IdentityManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdentityManager.API.Identity
{
    public interface IAuthenticationService
    {
        Task<ActionResult<ResultViewModel>> RegisterUserAsync(RegisterViewModel model, CancellationToken ct);
        Task<ActionResult<ResultViewModel>> ConfirmEmailAsync(string email, string token);
        Task<ActionResult<ResultViewModel>> ForgetPasswordAsync(string email, CancellationToken ct);
        Task<ActionResult<ResultViewModel>> ResetPasswordAsync(ResetPasswordViewModel model, CancellationToken ct);
        Task<UserResponseModel> GetUserById(int id, CancellationToken ct);
        Task<IEnumerable<UserResponseModel>> GetUsers(CancellationToken ct);
        Task<AgencyResponseModel> GetAgencyById(int id, CancellationToken ct);
    }
}
