using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Travely.PropertyManager.Data.Contracts.Repositories;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Queries;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;
using Travely.PropertyManager.Domain.Contracts.Services;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Domain.Services
{
    public class PropertyService : ServiceBase, IPropertyService
    {
        private readonly IPropertyRepository _repository;

        public PropertyService(ILogger<PropertyService> logger, IMapper mapper, IPropertyRepository repository)
            : base(logger, mapper)
        {
            _repository = repository;
        }

        public Task AddAsync(AddPropertyCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<PropertyResponse>> GetAsync(GetPropertiesQuery query)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PropertyResponse> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            return Mapper.Map<Property, PropertyResponse>(result);
        }
    }
}
