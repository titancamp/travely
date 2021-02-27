using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces.Repositories;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal class ActivityTypeRepository : Repository<ActivityType>, IActivityTypeRepository
    {
        private readonly ServiceManagerDbContext _serviceManagerDbContext;
        public ActivityTypeRepository(ServiceManagerDbContext serviceManagerDbContext)
            : base(serviceManagerDbContext)
        {
            _serviceManagerDbContext = serviceManagerDbContext;
        }

        public async Task<ActivityType> GetActivityTypeAsync(long agencyId, string activityTypeName)
        {
            return await _serviceManagerDbContext.ActivityTypes
                .Where(x => x.AgencyId == agencyId && x.Name == activityTypeName)
                .SingleOrDefaultAsync();
        }
    }
}
