using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;

namespace Travely.PropertyManager.Service.Contracts
{
    public interface IPropertyService
    {
        Task<int> AddAsync(int agencyId, AddPropertyCommand command);

        Task<int> EditAsync(int agencyId, EditPropertyCommand command);

        Task DeleteAsync(int agencyId, int id);

        Task<PropertyResponse> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponse>> GetAsync(int agencyId, GetPropertiesQuery query);

        Task<IEnumerable<RoomTypeResponse>> GetRoomTypesAsync();
    }
}
