using Travely.ClientManager.Abstraction.Abstraction.Repository;
using Travely.ClientManager.Abstraction.Entity;

namespace Travely.ClientManager.Repository.Repository
{
    public class PreferenceRepository : BaseRepository<Preference>, IPreferenceRepository
    {
        public PreferenceRepository(TouristContext dbContext) : base(dbContext)
        { 
        }
    }
}
