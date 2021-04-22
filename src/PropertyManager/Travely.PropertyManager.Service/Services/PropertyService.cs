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

        public async Task<int> AddAsync(int agencyId, AddPropertyCommand command)
        {
            var propertyModel = Mapper.Map<AddPropertyCommand, Property>(command, opt =>
                opt.AfterMap((src, dest) => dest.AgencyId = agencyId));

            _dbContext.Properties.Add(propertyModel);
            await _dbContext.SaveChangesAsync();

            return propertyModel.Id;
        }

        public async Task<int> EditAsync(int agencyId, EditPropertyCommand command)
        {
            var property = await GetByIdCoreAsync(agencyId, command.Id);

            var propertyModel = Mapper.Map(command, property);

            _dbContext.Properties.Update(propertyModel);
            await _dbContext.SaveChangesAsync();

            return propertyModel.Id;
        }

        public async Task DeleteAsync(int agencyId, int id)
        {
            var property = await GetByIdCoreAsync(agencyId, id);

            _dbContext.Properties.Remove(property);

            await _dbContext.SaveChangesAsync();
        }

        public async Task<PropertyResponse> GetByIdAsync(int agencyId, int id)
        {
            var property = await GetByIdCoreAsync(agencyId, id);

            return Mapper.Map<PropertyResponse>(property);
        }

        public async Task<IEnumerable<PropertyResponse>> GetAsync(int agencyId, GetPropertiesQuery query)
        {
            var propertiesQuery = _dbContext.Properties.Include(item => item.Attachments)
                .Where(item => item.AgencyId == agencyId)
                .AsQueryable();

            propertiesQuery = BuildFilters(propertiesQuery, query.Filters);
            propertiesQuery = BuildOrderings(propertiesQuery, query.Orderings);

            var properties = await propertiesQuery.AsNoTracking().ToListAsync();

            return Mapper.Map<IEnumerable<Property>, IEnumerable<PropertyResponse>>(properties);
        }

        public async Task<IEnumerable<RoomTypeResponse>> GetRoomTypesAsync()
        {
            var roomTypes = await _dbContext.RoomTypes.ToListAsync();

            return Mapper.Map<IEnumerable<RoomTypeResponse>>(roomTypes);
        }

        public async Task<Property> GetByIdCoreAsync(int agencyId, int id)
        {
            return await _dbContext.Properties.Include(item => item.Attachments)
                .FirstOrDefaultAsync(item => item.Id == id && item.AgencyId == agencyId)
                ?? throw new Exception("Property not found");
        }
    }
}
