using System.Collections.Generic;
using System.Threading.Tasks;
using TourManager.Service.Model.PropertyManager;

namespace TourManager.Service.Abstraction
{
    public interface IPropertyService
    {
        Task<int> AddAsync(int agencyId, AddEditPropertyRequestModel request);

        Task<int> EditAsync(int agencyId, int id, AddEditPropertyRequestModel request);

        Task DeleteAsync(int agencyId, int id);

        Task<PropertyResponseModel> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponseModel>> GetAsync(int agencyId);

        public Task<IEnumerable<RoomTypeResponseModel>> GetRoomTypesAsync();
    }
}
