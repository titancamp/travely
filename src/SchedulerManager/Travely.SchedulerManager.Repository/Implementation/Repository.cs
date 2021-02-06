using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travely.SchedulerManager.Repository.Interfaces;

namespace Travely.SchedulerManager.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly SchedulerDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        protected Repository(SchedulerDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }
        public ValueTask<TEntity> FirstAsync(int id)
        {
            return _dbSet.FindAsync(id);
        }
        public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.AnyAsync(predicate);
        }
        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }
        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
        }
        public void Remove(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public async Task<bool> SaveAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
