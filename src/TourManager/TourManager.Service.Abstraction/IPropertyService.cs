using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Common.Clients.PropertyManager;

namespace TourManager.Service.Abstraction
{
    public interface IPropertyService
    {
        Task<int> AddAsync(AddPropertyRequest request);

        Task<IEnumerable<PropertyResponse>> GetAsync();
    }
}
