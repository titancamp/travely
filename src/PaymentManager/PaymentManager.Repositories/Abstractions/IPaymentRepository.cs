using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PaymentManager.Repositories.Filters;
using PaymentManager.Repositories.Models;

namespace PaymentManager.Repositories
{
    public interface IPaymentRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int agencyId, int id);
        IQueryable<TEntity> GetAll(int agencyId, bool includeItems, PaymentQueryParameters parameters, IFilter<TEntity> filter);
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(List<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
