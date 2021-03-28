using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Clients.Abstraction.PropertyManager
{
    public interface IPropertyManagerClient
    {
        Task<int> AddPropertyAsync(int agencyId, AddPropertyRequest model);

        Task DeletePropertyAsync(int agencyId, int id);

        Task<PropertyResponse> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponse>> GetPropertiesAsync(int agencyId);
    }
}
