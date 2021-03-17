using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Clients.Abstraction.PropertyManager
{
    public interface IPropertyManagerClient
    {
        Task<int> AddPropertyAsync(AddPropertyRequest model);

        Task<IEnumerable<PropertyResponse>> GetPropertiesAsync();
    }
}
