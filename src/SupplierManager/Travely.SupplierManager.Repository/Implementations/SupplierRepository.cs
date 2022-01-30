using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;
using Travely.SupplierManager.Repository.Filters;

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
            var query = DbSet.Where(e => e.AgencyId == agencyId);
            
            return query.FirstOrDefaultAsync(supplier => supplier.Id == id);
        }

        public IQueryable<TEntity> GetAll(int agencyId, Filter<TEntity> filter)
        {
            var query = DbSet
                .Where(e => e.AgencyId == agencyId)
                .AsNoTracking();

            query = query.Filter(filter);

            return query;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            var entityEntry = DbSet.Add(entity);
            await DbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var entityEntry = DbSet.Update(entity);
            await DbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);

            return DbContext.SaveChangesAsync();
        }
    }
}
