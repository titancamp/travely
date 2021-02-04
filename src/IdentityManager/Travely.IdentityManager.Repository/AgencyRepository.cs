using Travely.IdentityManager.IRepository;
using Travely.IdentityManager.Repository.Model.AppEntities;
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
