using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Clients.Abstraction.PropertyManager;
using TourManager.Service.Abstraction;
using TourManager.Service.Model.PropertyManager;

namespace TourManager.Service.Implementation
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyManagerClient _client;

        public PropertyService(IPropertyManagerClient client)
        {
            _client = client;
        }

        public async Task<int> AddAsync(int agencyId, AddEditPropertyRequestModel request)
        {
            return await _client.AddPropertyAsync(agencyId, request);
        }

        public async Task<int> EditAsync(int agencyId, int id, AddEditPropertyRequestModel request)
        {
            return await _client.EditPropertyAsync(agencyId, id, request);
        }


        public async Task DeleteAsync(int agencyId, int id)
        {
            var property = await _client.GetByIdAsync(agencyId, id);

            await _client.DeletePropertyAsync(agencyId, id);
        }

        public Task<PropertyResponseModel> GetByIdAsync(int agencyId, int id)
        {
            return _client.GetByIdAsync(agencyId, id);
        }

        public Task<IEnumerable<PropertyResponseModel>> GetAsync(int agencyId)
        {
            return _client.GetPropertiesAsync(agencyId);
        }

        public Task<IEnumerable<RoomTypeResponseModel>> GetRoomTypesAsync()
        {
            return _client.GetRoomTypesAsync();
        }
    }
}
