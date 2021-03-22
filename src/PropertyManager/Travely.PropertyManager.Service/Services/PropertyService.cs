using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Data.Models;
using Travely.PropertyManager.Service.Contracts;
using Travely.PropertyManager.Service.Models.Commands;
using Travely.PropertyManager.Service.Models.Queries;
using Travely.PropertyManager.Service.Models.Responses;

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

        public async Task DeleteAsync(int id)
        {
            var property = await GetByIdCoreAsync(id);

            _dbContext.Properties.Remove(property);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PropertyResponse> GetByIdAsync(int id)
        {
            var property = await GetByIdCoreAsync(id);

            return Mapper.Map<PropertyResponse>(property);
        }

        public async Task<IEnumerable<PropertyResponse>> GetAsync(GetPropertiesQuery query)
        {
            var propertiesQuery = _dbContext.Properties.Include(item => item.Attachments).AsQueryable();

            propertiesQuery = BuildFilters(propertiesQuery, query.Filters);
            propertiesQuery = BuildOrderings(propertiesQuery, query.Orderings);

            var properties = await propertiesQuery.ToListAsync();

            return Mapper.Map<IEnumerable<Property>, IEnumerable<PropertyResponse>>(properties);
        }

        public async Task<Property> GetByIdCoreAsync(int id)
        {
            return await _dbContext.Properties.Include(item => item.Attachments).FirstOrDefaultAsync(item => item.Id == id)
                ?? throw new Exception("Property not found");
        }
    }
}
