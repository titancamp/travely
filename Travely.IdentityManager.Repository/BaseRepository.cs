using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Travely.IdentityManager.IRepository;

namespace Travely.IdentityManager.Repository
{
    public class BaseRepository<TEntity, U> : IBaseRepository<TEntity> where TEntity : class, new()
                                                             where U : DbContext, new()
    {
        protected U DbContext { get; private set; }
        public BaseRepository(U dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            DbContext.Set<TEntity>().Add(entity);
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        { 
            return DbContext.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbContext.Set<TEntity>().FindAsync(id);
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException("entity");
            }
            var modified = DbContext.ChangeTracker.Entries<TEntity>().Where(x => x.State == EntityState.Modified).Count();
            if (modified > 0)
            {
                DbContext.Set<TEntity>().Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;

            }
            return entity;
        }
    }
}
