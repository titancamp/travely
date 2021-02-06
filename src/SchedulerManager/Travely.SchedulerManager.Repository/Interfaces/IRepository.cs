using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Repository.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> FirstAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate);
        void Update(TEntity entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void Remove(IEnumerable<TEntity> entities);
        Task<bool> SaveAsync();
    }
}