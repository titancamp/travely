using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Clients.Abstraction.PropertyManager
{
    public interface IPropertyManagerClient
    {
        Task<int> AddPropertyAsync(AddPropertyRequest model);

        Task DeletePropertyAsync(int id);

        Task<PropertyResponse> GetByIdAsync(int id);

        Task<IEnumerable<PropertyResponse>> GetPropertiesAsync();
    }
}
