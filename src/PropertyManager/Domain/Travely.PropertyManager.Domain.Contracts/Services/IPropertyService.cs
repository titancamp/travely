using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Queries;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;

namespace Travely.PropertyManager.Domain.Contracts.Services
{
    public interface IPropertyService
    {
        Task<int> AddAsync(AddPropertyCommand command);

        Task<ICollection<PropertyResponse>> GetAsync(GetPropertiesQuery query);
    }
}
