using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;

namespace Travely.PropertyManager.Service.Contracts
{
    public interface IPropertyService
    {
        Task<int> AddAsync(AddPropertyCommand command);

        Task DeleteAsync(int id);

        Task<PropertyResponse> GetByIdAsync(int id);

        Task<IEnumerable<PropertyResponse>> GetAsync(GetPropertiesQuery query);
    }
}
