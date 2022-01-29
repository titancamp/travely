using System.Linq;

namespace Travely.SupplierManager.Repository.Filters
{
    public abstract class Filter<TEntity>
    {
        public string Order { get; set; }

        public abstract IQueryable<TEntity> Apply(IQueryable<TEntity> query);
    }
}