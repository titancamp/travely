using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Service.Abstraction
{
    public interface IPropertyService
    {
        Task<int> AddAsync(int agencyId, AddPropertyRequestDto request);

        Task<int> EditAsync(int agencyId, EditPropertyRequestDto request);

        Task DeleteAsync(int agencyId, int id);

        Task<PropertyResponseDto> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponseDto>> GetAsync(int agencyId);
    }
}
