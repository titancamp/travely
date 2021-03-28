using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Service.Abstraction
{
    public interface IPropertyService
    {
        Task<int> AddAsync(int agencyId, AddPropertyRequest request);

        Task DeleteAsync(int agencyId, int id);

        Task<PropertyResponse> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponse>> GetAsync(int agencyId);
    }
}
