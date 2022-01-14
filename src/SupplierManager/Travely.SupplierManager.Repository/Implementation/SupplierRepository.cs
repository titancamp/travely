using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class SupplierRepository<TEntity> : ISupplierRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly SupplierDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public SupplierRepository(SupplierDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = dbContext.Set<TEntity>();
        }

        public Task<TEntity> GetByIdAsync(int agencyId, int id)
        {
            var query = DbSet.AsQueryable()
                .AsNoTracking();
            
            return query.FirstOrDefaultAsync(supplier => supplier.Id == id);
        }

        public IQueryable<TEntity> GetAll(int agencyId)
        {
            var query = DbSet
                .Where(e => e.AgencyId == agencyId)
                .AsNoTracking();

            return query;
        }

        public Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var query = DbSet
                .AsNoTracking()
                .Where(predicate);

            return query.ToListAsync();
        }

        public Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = DbSet
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);
            
            return entity;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = DbSet.Add(entity);
            await DbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRangeAsync(List<TEntity> entities)
        {
            DbSet.AddRange(entities);

            return DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityEntry = DbSet.Update(entity);
            await DbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task UpdateRangeAsync(List<TEntity> entities)
        {
            DbSet.UpdateRange(entities);

            return DbContext.SaveChangesAsync();
        }

        public Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);

            return DbContext.SaveChangesAsync();
        }

        public Task RemoveRangeAsync(List<TEntity> entities)
        {
            DbSet.RemoveRange(entities);

            return DbContext.SaveChangesAsync();
        }
    }
}
