using System.Linq;
using PaymentManager.Repositories.Entities;

namespace PaymentManager.Repositories.Filters
{
    public interface IFilter<TEntity>
    {
        public IQueryable<TEntity> ApplyFilter(IQueryable<TEntity> query);
    }
}