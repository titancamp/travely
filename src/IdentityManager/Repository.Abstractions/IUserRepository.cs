using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.Abstractions
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<User?> FindByEmailAsync(string username, CancellationToken cancaletionToken = default);
    }
}
