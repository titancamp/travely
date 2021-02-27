using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManager.Common.Clients;

namespace TourManager.Clients.Abstraction.ServiceManager
{
    public interface IServiceManagerClient
    {
        Task<ActivityResponse> CreateActivityAsync(Activity activity);
        Task<ActivityResponse> EditActivityAsync(Activity activity);
        Task<ActivityResponse> DeleteActivityAsync(long ActivityId);
        Task<IEnumerable<Activity>> GetActivitiesAsync(int AgencyId);
    }
}
