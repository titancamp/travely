using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Models.Db;

namespace Travely.ServiceManager.Abstraction.Interfaces
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task<List<Activity>> GetAllActivitiesAsync(long agencyId);
        Task<Activity> GetActivityAsync(long agencyId, string activityName, long activityTypeId);
    }
}
