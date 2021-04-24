using TourManager.Repository.Abstraction;
using TourManager.Repository.EfCore.Context;
using TourManager.Repository.Entities;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    public class PropertyRepository : BaseRepository<PropertyEntity>, IPropertyRepository
    {
        public PropertyRepository(TourDbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
