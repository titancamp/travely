using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Travely.IdentityManager.Repository.Abstractions;

namespace Travely.IdentityManager.Repository
{
    public class BaseRepository<TEntity, TDBContext> : IBaseRepository<TEntity> where TEntity : class, new()
                                                             where TDBContext : DbContext, new()
    {
        protected TDBContext DbContext { get; private set; }
        protected DbSet<TEntity> Set => DbContext.Set<TEntity>();
        public BaseRepository(TDBContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual TEntity Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            Set.Add(entity);
            return entity;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return Set;
        }

        public virtual async Task<TEntity> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return await Set.FindAsync(id, cancellationToken);
        }

        public TEntity Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            var modified = DbContext.ChangeTracker.Entries<TEntity>().Where(x => x.State == EntityState.Modified).Count();
            if (modified > 0)
            {
                Set.Attach(entity);
                DbContext.Entry(entity).State = EntityState.Modified;

            }
            return entity;
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await Set.SingleAsync(expression, cancellationToken);
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentException(nameof(entity));
            }
            Set.Remove(entity);
        }
    }
}
