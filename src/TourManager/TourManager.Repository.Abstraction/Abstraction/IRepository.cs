using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TourManager.Repository.Abstraction
{
    /// <summary>
    /// Base repository interface
    /// </summary>
    /// <typeparam name="TEntity">The entity type</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Get entity asynchronously by id 
        /// </summary>
        /// <param name="id">The entity id</param>
        /// <returns></returns>
        Task<TEntity> GetById(int id);

        /// <summary>
        /// Get all entities asynchronously
        /// </summary>
        /// <returns></returns>
        Task<List<TEntity>> GetAll();

        /// <summary>
        /// Find entities by predicate
        /// </summary>
        /// <param name="predicate">The predicate to find with</param>
        /// <returns></returns>
        Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Find single entity asynchronously by predicate
        /// </summary>
        /// <param name="predicate">The predicate to find with</param>
        /// <returns></returns>
        Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Add single entity asynchronously
        /// </summary>
        /// <param name="entity">The entity to add</param>
        /// <returns></returns>
        Task<TEntity> Add(TEntity entity);

        /// <summary>
        /// Add several entities asynchronously
        /// </summary>
        /// <param name="entities">The entitiies collection to add</param>
        /// <returns></returns>
        Task AddRange(List<TEntity> entities);

        /// <summary>
        /// Update single entity asynchronously
        /// </summary>
        /// <param name="entity">The entity to update</param>
        /// <returns></returns>
        public Task Update(TEntity entity);

        /// <summary>
        /// Update several entities asynchronously
        /// </summary>
        /// <param name="entities">The entitiies collection to update</param>
        /// <returns></returns>
        public Task UpdateRange(List<TEntity> entities);

        /// <summary>
        /// Remove single entity
        /// </summary>
        /// <param name="entity">The entity to remove</param>
        /// <returns></returns>
        Task Remove(TEntity entity);

        /// <summary>
        /// Remove several entities
        /// </summary>
        /// <param name="entities">The entities collection to remove</param>
        /// <returns></returns>
        Task RemoveRange(List<TEntity> entities);
    }
}