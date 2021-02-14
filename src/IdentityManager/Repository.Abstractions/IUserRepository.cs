using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancaletionToken = default);
        Task<bool?> CheckPasswordAsync(string username, string Password, CancellationToken cancaletionToken = default);
    }
}
