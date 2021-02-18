using IdentityManager.API.Models;
using IdentityManager.WebApi.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdentityManager.API.Identity
{
    public interface IAuthenticationService
    {
        Task<Models.AuthResponse> RegisterUserAsync(RegisterViewModel model);
        Task<Models.AuthResponse> LoginUserAsync(LoginViewModel model);
        Task<Models.AuthResponse> ConfirmEmailAsync(string email, string token);
        Task<Models.AuthResponse> ForgetPasswordAsync(string email);
        Task<Models.AuthResponse> ResetPasswordAsync(ResetPasswordViewModel model);
        Task<UserResponseModel> GetUserById(int id);
        Task<UserResponseModel> GetUserByUserName(string userName);
        Task<IEnumerable<UserResponseModel>> GetUsers();
        Task<AgencyResponseModel> GetAgencyByName(string agencyName);
        Task<AgencyResponseModel> GetAgencyById(int id);
    }
}
