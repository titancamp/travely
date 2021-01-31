using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Travely.ServiceManager.Abstraction.Interfaces;
using Travely.ServiceManager.Abstraction.Models.Db;
using Travely.ServiceManager.DAL.Data;

namespace Travely.ServiceManager.DAL.Repositories
{
    internal abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ServiceManagerDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(ServiceManagerDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }
        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            var dbEntity = await _dbSet.AddAsync(entity);
            return dbEntity.Entity;
        }

        public virtual async Task DeleteAsync(int entityId)
        {
            var entity = await _dbSet.FindAsync(entityId);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity> GetAsync(int entityId)
        {
            return await _dbSet.FindAsync(entityId);
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
