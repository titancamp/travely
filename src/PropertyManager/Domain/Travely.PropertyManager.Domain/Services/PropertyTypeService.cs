using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Domain.Contracts.Models.Commands;
using Travely.PropertyManager.Domain.Contracts.Models.Queries;
using Travely.PropertyManager.Domain.Contracts.Models.Responses;
using Travely.PropertyManager.Domain.Contracts.Services;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Domain.Services
{
    public class PropertyTypeService : ServiceBase, IPropertyTypeService
    {
        private readonly PropertyDbContext _dbContext;

        public PropertyTypeService(ILogger<PropertyService> logger, IMapper mapper, PropertyDbContext dbContext)
          : base(logger, mapper)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(AddPropertyTypeCommand command)
        {
            var entity = Mapper.Map<AddPropertyTypeCommand, PropertyType>(command);
            await _dbContext.PropertyTypes.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
        public async Task<PropertyTypeResponse> GetByIdAsync(int id)
        {
            var dbModel = await _dbContext.PropertyTypes.FirstOrDefaultAsync(x => x.Id == id);
            return Mapper.Map<PropertyType, PropertyTypeResponse>(dbModel);
        }

        public async Task<ICollection<PropertyTypeResponse>> GetAsync(GetPropertyTypesQuery query)
        {
            var dbModels = _dbContext.PropertyTypes.AsEnumerable();
            return dbModels.Select(x => Mapper.Map<PropertyType, PropertyTypeResponse>(x)).ToList();
        }

    }
}
