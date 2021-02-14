using Travely.IdentityManager.Repository.Abstractions;
using Travely.IdentityManager.Repository.Abstractions.Entities;
using Travely.IdentityManager.Repository.Model.Context;

namespace Travely.IdentityManager.Repository
{
    public class AgencyRepository : BaseRepository<Agency, IdentityServerDbContext>, IAgencyRepository
    {
        public AgencyRepository(IdentityServerDbContext identityServerDbContext) : base(identityServerDbContext)
        {

        }
    }
}
