using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;
using Travely.PropertyManager.Service.Contracts;
using Travely.PropertyManager.Data.EntityFramework;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Travely.PropertyManager.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Travely.PropertyManager.Service.Services
{
    public class PropertyService : ServiceBase, IPropertyService
    {
        private readonly PropertyDbContext _dbContext;

        public PropertyService(ILogger<PropertyService> logger, IMapper mapper, PropertyDbContext propertyDbContext)
            : base(logger, mapper)
        {
            _dbContext = propertyDbContext;
        }

        public async Task<int> AddAsync(AddPropertyCommand command)
        {
            var propertyModel = Mapper.Map<AddPropertyCommand, Property>(command);
            _dbContext.Properties.Add(propertyModel);

            await _dbContext.SaveChangesAsync();
            return propertyModel.Id;
        }

        public async Task<IEnumerable<PropertyResponse>> GetAsync(GetPropertiesQuery query)
        {
            IQueryable<Property> propertiesQueryable = _dbContext.Properties.AsQueryable();

            propertiesQueryable = base.BuildFilters(propertiesQueryable, query.Filters);
            propertiesQueryable = base.BuildOrderings(propertiesQueryable, query.Orderings);

            var dbProperties = await propertiesQueryable.ToListAsync();
            return dbProperties.Select(Mapper.Map<Property, PropertyResponse>);
        }
    }
}
