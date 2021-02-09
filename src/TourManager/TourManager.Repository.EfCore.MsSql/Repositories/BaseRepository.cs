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

        public Task<TEntity> GetByIdAsync(int id)
        {
            return Context.Set<TEntity>().FindAsync(id).AsTask();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            var query = Context.Set<TEntity>().AsNoTracking();

            return query.ToListAsync();
        }

        public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Context.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);

            return query.ToListAsync();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);

            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = Context.Set<TEntity>().Add(entity);
            await Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRangeAsync(List<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);
            return Context.SaveChangesAsync();
        }

        public Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            return Context.SaveChangesAsync();
        }

        public Task RemoveRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            return Context.SaveChangesAsync();
        }
    }
}