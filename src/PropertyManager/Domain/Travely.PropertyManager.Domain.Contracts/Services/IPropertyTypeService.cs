using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Queries;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;

namespace Travely.PropertyManager.Domain.Contracts.Services
{
    public interface IPropertyTypeService
    {
        Task AddAsync(AddPropertyTypeCommand command);

        Task<PropertyTypeResponse> GetByIdAsync(int id);

        Task<ICollection<PropertyTypeResponse>> GetAsync(GetPropertyTypesQuery query);
    }
}
