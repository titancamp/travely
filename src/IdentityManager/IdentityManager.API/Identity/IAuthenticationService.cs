using Docker.DotNet.Models;
using IdentityManager.API.Models;
using System.Threading.Tasks;

namespace IdentityManager.API.Identity
{
   public interface IAuthenticationService
    {
        Task<Models.AuthResponse> RegisterUserAsync(RegisterViewModel model);

        Task<Models.AuthResponse> LoginUserAsync(LoginViewModel model);

        Task<Models.AuthResponse> ConfirmEmailAsync(string userId, string token);

        Task<Models.AuthResponse> ForgetPasswordAsync(string email);

        Task<Models.AuthResponse> ResetPasswordAsync(ResetPasswordViewModel model);

        Task<Models.AuthResponse> RefreshToken(Models.AuthResponse model);
    }
}
