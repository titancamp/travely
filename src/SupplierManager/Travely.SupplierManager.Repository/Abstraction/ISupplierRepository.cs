using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Travely.SupplierManager.Repository
{
    public interface ISupplierRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int agencyId, int id);
        IQueryable<TEntity> GetAll(int agencyId);
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        public Task<TEntity> UpdateAsync(TEntity entity);
        public Task UpdateRangeAsync(List<TEntity> entities);
        Task RemoveAsync(TEntity entity);
        Task RemoveRangeAsync(List<TEntity> entities);
    }
}