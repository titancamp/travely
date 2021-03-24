using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces.Repositories;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        private readonly ServiceManagerDbContext _serviceManagerDbContext;

        public ActivityRepository(ServiceManagerDbContext serviceManagerDbContext)
            : base(serviceManagerDbContext)
        {
            _serviceManagerDbContext = serviceManagerDbContext;
        }

        public async Task<List<Activity>> GetAllActivitiesAsync(long agencyId)
        {
            return await _serviceManagerDbContext.Activities
                .Include(x => x.ActivityType)
                .Where(x => x.ActivityType.AgencyId == agencyId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Activity> GetActivityAsync(long agencyId, string activityName, long activityTypeId)
        {
            return await _serviceManagerDbContext.Activities
                .Include(x => x.ActivityType)
                .Where(x => x.ActivityType.AgencyId == agencyId && x.Name == activityName && x.ActivityTypeId == activityTypeId)
                .AsNoTracking()
                .SingleOrDefaultAsync();
        }
    }
}
