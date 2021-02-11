using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Domain.Models.Commands;
using Travely.PropertyManager.Domain.Models.Queries;
using Travely.PropertyManager.Domain.Models.Responses;
using Travely.PropertyManager.Domain.Contracts;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Domain.Services
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

        public Task<ICollection<PropertyResponse>> GetAsync(GetPropertiesQuery query)
        {

            IQueryable<Property> propertiesQueryable = _dbContext.Properties.AsQueryable();

            propertiesQueryable = base.BuildFilters(propertiesQueryable, query.Filters);
            propertiesQueryable = base.BuildSortings(propertiesQueryable, query.Sortings);


            throw new System.NotImplementedException();
        } 
    }
}
