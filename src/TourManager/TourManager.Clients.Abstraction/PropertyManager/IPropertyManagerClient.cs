using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Clients.Abstraction.PropertyManager
{
    public interface IPropertyManagerClient
    {
        Task<int> AddPropertyAsync(int agencyId, AddPropertyRequestDto model);

        Task<int> EditPropertyAsync(int agencyId, EditPropertyRequestDto model);

        Task DeletePropertyAsync(int agencyId, int id);

        Task<PropertyResponseDto> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponseDto>> GetPropertiesAsync(int agencyId);
    }
}
