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

        public async Task<bool?> CheckPasswordAsync(string username, string password, CancellationToken cancaletionToken = default)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return null;
            }
            var user = await GetByConditionAsync(item => (item.UserName == username && item.Password == password), cancaletionToken);
            return user != null;
        }

        public async Task<User?> GetUserByUsernameAsync(string username, CancellationToken cancaletionToken = default)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return null;
            }
            return await GetByConditionAsync(item => item.UserName == username, cancaletionToken);
        }
    }
}
