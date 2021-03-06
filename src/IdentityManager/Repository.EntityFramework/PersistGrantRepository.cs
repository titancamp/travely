using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;

namespace Travely.IdentityManager.Repository.EntityFramework
{
    public class PersistGrantRepository : BaseRepository<PersistedGrant, IdentityServerDbContext>, IPersistGrantRepository
    {
        public PersistGrantRepository(IdentityServerDbContext dbContext) : base(dbContext)
        {
        }

        
    }

    
}
