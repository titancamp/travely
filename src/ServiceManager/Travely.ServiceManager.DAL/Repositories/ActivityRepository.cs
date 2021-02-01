using Travely.ServiceManager.Abstraction.Interfaces;
using Travely.ServiceManager.Abstraction.Models.Db;
using Travely.ServiceManager.DAL.Data;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(ServiceManagerDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
