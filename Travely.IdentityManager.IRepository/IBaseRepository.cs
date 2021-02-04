using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        TEntity Add(TEntity entity);
        TEntity Update(TEntity entity);
        IQueryable<TEntity> GetAll();
        Task<TEntity> GetByIdAsync(int id);
    }
}
