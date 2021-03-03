using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.EntityFramework
{
    public class UserRepository : BaseRepository<User, IdentityServerDbContext>, IUserRepository
    {
        public UserRepository(IdentityServerDbContext identityServerDbContext) : base(identityServerDbContext)
        {

        }

        public async Task<User?> FindByEmailAsync(string username, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            var user = await FindAsync(item => item.UserName == username, cancellationToken);
            return user;
        }
    }
}
