using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Travely.SupplierManager.Repository
{
    public interface ISupplierRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int agencyId, int id);
        Task<IQueryable<TEntity>> GetAll(int agencyId);
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity entity);
        Task AddRange(List<TEntity> entities);
        public Task<TEntity> Update(TEntity entity);
        public Task UpdateRange(List<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveRange(List<TEntity> entities);
    }
}