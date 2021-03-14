using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.EntityFramework
{

    public class UserEmailValidationModelRepository : BaseRepository<UserEmailValidationModel, IdentityServerDbContext>, IUserEmailValidationModelRepository
    {
        public UserEmailValidationModelRepository(IdentityServerDbContext identityServerDbContext) : base(identityServerDbContext)
        {

        }
    }
}
