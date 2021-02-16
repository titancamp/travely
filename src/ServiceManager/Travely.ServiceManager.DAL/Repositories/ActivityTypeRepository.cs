using Travely.ServiceManager.Abstraction.Interfaces.Repositories;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal class ActivityTypeRepository : Repository<ActivityType>, IActivityTypeRepository
    {
        public ActivityTypeRepository(ServiceManagerDbContext serviceManagerDbContext)
            : base(serviceManagerDbContext)
        {
        }
    }
}
