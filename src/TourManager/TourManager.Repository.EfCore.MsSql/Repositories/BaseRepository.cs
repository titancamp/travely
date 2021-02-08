using System;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TourManager.Repository.Abstraction;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public BaseRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var query = Context.Set<TEntity>().AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Context.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);

            return await query.ToListAsync();
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            await Context.SaveChangesAsync();
        }

        public async Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Context.SaveChangesAsync();
        }
    }
}