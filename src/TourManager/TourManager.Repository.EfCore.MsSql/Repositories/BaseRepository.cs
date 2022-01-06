using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TourManager.Repository.Abstraction;

namespace TourManager.Repository.EfCore.MsSql.Repositories
{
    /// <summary>
    /// The base repository for all entities
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public class BaseRepository<TContext, TEntity> : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly TContext Context;

        /// <summary>
        /// The database entity set
        /// </summary>
        protected readonly DbSet<TEntity> DbSet;

        /// <summary>
        /// Create new instance of base repository
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(TContext context)
        {
            this.Context = context;
            this.DbSet = Context.Set<TEntity>();
        }

        /// <summary>
        /// Get entity asynchronously by id 
        /// </summary>
        /// <param name="id">The entity id</param>
        /// <returns></returns>
        public Task<TEntity> GetById(int id)
        {
            return Context.Set<TEntity>().FindAsync(id).AsTask();
        }

        /// <summary>
        /// Get all entities asynchronously
        /// </summary>
        /// <returns></returns>
        public Task<List<TEntity>> GetAll()
        {
            var query = Context.Set<TEntity>().AsNoTracking();

            return query.ToListAsync();
        }

        /// <summary>
        /// Find entities by predicate
        /// </summary>
        /// <param name="predicate">The predicate to find with</param>
        /// <returns></returns>
        public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = Context.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);

            return query.ToListAsync();
        }

        /// <summary>
        /// Find single entity asynchronously by predicate
        /// </summary>
        /// <param name="predicate">The predicate to find with</param>
        /// <returns></returns>
        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = Context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);

            return entity;
        }

        /// <summary>
        /// Add single entity asynchronously
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns></returns>
        public async Task<TEntity> Add(TEntity entity)
        {
            var entityEntry = Context.Set<TEntity>().Add(entity);

            await Context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        /// <summary>
        /// Add several entities asynchronously
        /// </summary>
        /// <param name="entities">The entitiies collection to add</param>
        /// <returns></returns>
        public Task AddRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().AddRange(entities);

            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Update single entity asynchronously
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns></returns>
        public Task Update(TEntity entity)
        {
            Context.Set<TEntity>().Update(entity);

            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Update several entities asynchronously
        /// </summary>
        /// <param name="entities">The entitiies collection to update</param>
        /// <returns></returns>
        public Task UpdateRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().UpdateRange(entities);

            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove single entity
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        /// <returns></returns>
        public Task Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);

            return Context.SaveChangesAsync();
        }

        /// <summary>
        /// Remove several entities
        /// </summary>
        /// <param name="entities">The entities collection to remove</param>
        /// <returns></returns>
        public Task RemoveRange(List<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);

            return Context.SaveChangesAsync();
        }
    }
}