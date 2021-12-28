using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SupplierManager.Repository.Abstraction.Abstraction
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetById(int id);
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity entity);
        Task AddRange(List<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task UpdateRange(List<TEntity> entities);
        Task Remove(TEntity entity);
        Task RemoveRange(List<TEntity> entities);
    }
}