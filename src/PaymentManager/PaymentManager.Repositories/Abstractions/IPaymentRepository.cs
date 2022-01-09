using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories
{
    public interface IPaymentRepository<TEntity>
    {
        Task<TEntity> GetById(int agencyId, int id);
        Task<IQueryable<TEntity>> GetAll(int agencyId, bool includeItems);
        Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> Add(TEntity entity);
        Task AddRange(List<TEntity> entities);
        Task<TEntity> Update(TEntity entity);
        Task Remove(TEntity entity);
        Task RemoveRange(List<TEntity> entities);
    }
}
