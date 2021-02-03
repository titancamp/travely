using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Travely.ClientManager.Repository.Entity;

namespace Travely.ClientManager.Repository.Abstraction
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        IQueryable<T> Get(Expression<Func<T, bool>> predicate, params string[] includes);
        IQueryable<T> Get(params string[] includes);
        IQueryable<T> GetNoTracking(Expression<Func<T, bool>> predicate, params string[] includes);
        IQueryable<T> GetNoTracking(params string[] includes);
        void Add(T entity);

        void Update(T entity, params Expression<Func<T, object>>[] updatedProperties);
        void Delete(T entity);

        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}
