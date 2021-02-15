using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Repository.Model.Context;

namespace Travely.IdentityManager.Repository
{
    public class UserRepository : BaseRepository<User, IdentityServerDbContext>, IUserRepository
    {
        public UserRepository(IdentityServerDbContext identityServerDbContext) : base(identityServerDbContext)
        {

        }

        public async Task<User?> FindByEmailAsync(string username, CancellationToken cancaletionToken = default)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            return await GetByConditionAsync(item => item.UserName == username, cancaletionToken);
        }
    }
}
