using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Travely.SchedulerManager.Repository.Entities;
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
            return enableTracking ?   _dbSet.FirstOrDefaultAsync(s => s.Id == id) 
                                    : _dbSet.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
                                                             bool enableTracking = false)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            if (enableTracking)
                return await _dbSet.Where(predicate).ToListAsync();

            return await  _dbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public ValueTask<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.CreatedOn = DateTime.Now;
            return _dbSet.AddAsync(entity);
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var entity in entities)
            {
                entity.CreatedOn = DateTime.Now;
            }
            return _dbSet.AddRangeAsync(entities);
        }

        public void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.ModifiedOn = DateTime.Now;
            _dbSet.Update(entity);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));
            return _dbSet.AnyAsync(predicate);
        }

        public void Remove(long id)
        {
           var entity = _dbSet.Find(id);
           entity.IsDeleted = true;
        }

        public void Remove(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            entity.IsDeleted = true;
        }

        public void Remove(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));
            foreach (var entity in entities)
            {
                entity.IsDeleted = true;
            }
        }

        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
