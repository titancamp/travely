using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Abstraction.Interfaces
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task<List<Activity>> GetAllActivitiesByAgencyIdAsync(long agencyId);
        Task<Activity> GetActivityByNameAndTypeId(long agencyId, string activityName, long activityTypeId);
    }
}
