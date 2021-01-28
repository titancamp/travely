using Travely.ServiceManager.Core.Interfaces;
using Travely.ServiceManager.Core.Models.Db;
using Travely.ServiceManager.DAL.Data;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal class ActivityRepository : GenericRepository<Activity>, IActivityRepository
    {
        public ActivityRepository(ServiceManagerDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
