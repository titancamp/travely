using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Common.Clients.PropertyManager;
using TourManager.Service.Abstraction;

namespace TourManager.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyManagerClient _client;

        public PropertyService(IPropertyManagerClient client)
        {
            _client = client;
        }

        public Task<int> AddAsync(AddPropertyRequest request)
        {
            return _client.AddPropertyAsync(request);
        }

        public Task<IEnumerable<PropertyResponse>> GetAsync()
        {
            return _client.GetPropertiesAsync();
        }
    }
}
