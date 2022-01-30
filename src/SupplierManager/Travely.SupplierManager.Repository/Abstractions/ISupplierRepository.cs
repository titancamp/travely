using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Travely.SupplierManager.Repository.Filters;

namespace Travely.SupplierManager.Repository
{
    public interface ISupplierRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int agencyId, int id);
        IQueryable<TEntity> GetAll(int agencyId, Filter<TEntity> filter);
        Task<TEntity> AddAsync(TEntity entity);
        public Task<TEntity> UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}