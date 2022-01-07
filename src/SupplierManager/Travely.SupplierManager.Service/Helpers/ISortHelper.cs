using System.Linq;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Service.Helpers
{
    public interface ISortHelper<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Order(IQueryable<TEntity> query, string orderBy);
    }
}