using System.Linq;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.Filters
{
    public class ActivitiesFilter : Filter<ActivitiesEntity>
    {
        public override IQueryable<ActivitiesEntity> Apply(IQueryable<ActivitiesEntity> query)
        {
            return query;
        }
    }
}
