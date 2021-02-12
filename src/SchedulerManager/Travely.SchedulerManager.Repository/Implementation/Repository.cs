using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Travely.SchedulerManager.Repository.Infrastructure.EntityConfigurations;
using Travely.SchedulerManager.Repository.Infrastructure.Interfaces;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly SchedulerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(SchedulerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public Task<TEntity> FindAsync(long id, bool enableTracking = false)
        {
            var query = _dbSet.AsQueryable();
            if (!enableTracking)
            {
                query = _dbSet.AsNoTracking();
            }
            return query.SingleAsync(s => s.Id == id && s.Active);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
                                                             bool enableTracking = false)
        {
            var query = _dbSet.AsQueryable();
            if (!enableTracking)
            {
                query = _dbSet.AsNoTracking();
            }
            return await query.Where(s => s.Active).Where(predicate).ToListAsync();
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.CreatedOn = new DateTime();
            entity.ModifiedOn = new DateTime();
            return _dbSet.AddAsync(entity);
        }
        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var entity in entities)
            {
                entity.CreatedOn = new DateTime();
                entity.ModifiedOn = new DateTime();
            }
            return _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.ModifiedOn = new DateTime();
            _dbSet.Update(entity);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(s => s.Active).AnyAsync(predicate);
        }

        public void Remove(long id)
        {
           var entity = _dbSet.Find(id);
           entity.Active = false;
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.Active = false;
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var entity in entities)
            {
                entity.Active = false;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
