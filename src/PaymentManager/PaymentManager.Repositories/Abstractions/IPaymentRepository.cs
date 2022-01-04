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
        Task<TEntity> GetByIdAsync(int agencyId, int id);
        IQueryable<TEntity> GetAll(int agencyId, bool includeItems);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
