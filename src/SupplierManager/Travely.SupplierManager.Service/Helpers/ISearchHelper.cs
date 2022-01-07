using System.Linq;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Service.Helpers
{
    public interface ISearchHelper<TEntity> 
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> Search(IQueryable<TEntity> query, string search);
    }
}