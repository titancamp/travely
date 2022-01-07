using System.Linq;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Service.Helpers
{
    public class AccommodationSearchHelper : ISearchHelper<AccommodationEntity>
    {
        public IQueryable<AccommodationEntity> Search(IQueryable<AccommodationEntity> query, string search)
        {
            if (!query.Any() || string.IsNullOrWhiteSpace(search))
            {
                return query; 
            }

            search = search.Trim().ToLower();
            var newQuery = query.Where(e =>
                e.Name.ToLower().Contains(search));

            return newQuery;
        }
    }
}