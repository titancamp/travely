using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PropertyManager.Grpc.Models;

namespace Travely.PropertyManager.Grpc.Client.Abstraction
{
    public interface IPropertyManagerClient
    {
        Task<int> AddPropertyAsync(int agencyId, AddEditPropertyRequestModel model);

        Task<int> EditPropertyAsync(int agencyId, int id, AddEditPropertyRequestModel model);

        Task DeletePropertyAsync(int agencyId, int id);

        Task<PropertyResponseModel> GetByIdAsync(int agencyId, int id);

        Task<IEnumerable<PropertyResponseModel>> GetPropertiesAsync(int agencyId);
    }
}
