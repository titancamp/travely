using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travely.PropertyManager.Data.Contracts.Repositories;
using Travely.PropertyManager.Data.EntityFramework;
using Travely.PropertyManager.Domain.Entities;

namespace Travely.PropertyManager.Data.Repositories
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly PropertyDbContext _dbContext;

        public PropertyRepository(PropertyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Property> GetByIdAsync(int id)
        {
            return _dbContext.Properties.FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
