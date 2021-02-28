using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Abstraction.Interfaces.Repositories
{
    public interface IActivityTypeRepository : IRepository<ActivityType>
    {
        Task<ActivityType> GetActivityTypeAsync(long agencyId, string activityTypeName);
        Task<List<ActivityType>> SearchActivityTypesAsync(long agencyId, string activityTypeName);
    }
}
