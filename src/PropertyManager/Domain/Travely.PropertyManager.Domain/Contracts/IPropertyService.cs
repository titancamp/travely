using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PropertyManager.Domain.Models.Commands;
using Travely.PropertyManager.Domain.Models.Queries;
using Travely.PropertyManager.Domain.Models.Responses;

namespace Travely.PropertyManager.Domain.Contracts
{
    public interface IPropertyService
    {
        Task<int> AddAsync(AddPropertyCommand command);

        Task<IEnumerable<PropertyResponse>> GetAsync(GetPropertiesQuery query);
    }
}
