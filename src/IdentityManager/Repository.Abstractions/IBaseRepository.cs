using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        void Remove(TEntity entity);
        Task<TEntity> FindByIdAsync(int id, CancellationToken cancaletionToken = default);
        Task<TEntity> GetByConditionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancaletionToken = default);
    }
}
