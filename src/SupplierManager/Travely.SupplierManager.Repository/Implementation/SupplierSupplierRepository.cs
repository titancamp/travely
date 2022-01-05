using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Travely.SupplierManager.Repository;
using Travely.SupplierManager.Repository.DbContexts;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository
{
    public class SupplierSupplierRepository<TEntity> : ISupplierRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly SupplierDbContext DbContext;
        protected readonly DbSet<TEntity> DbSet;

        public SupplierSupplierRepository(SupplierDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            DbSet = dbContext.Set<TEntity>();
        }

        public Task<TEntity> GetById(int agencyId, int id)
        {
            var query = DbSet.AsQueryable()
                // .Include(e => e.RoomEntity)
                .AsNoTracking();
            
            return query.FirstOrDefaultAsync(supplier => supplier.Id == id);
            // return DbContext.Set<TEntity>().FindAsync(id).AsTask();
        }

        public async Task<IQueryable<TEntity>> GetAll(int agencyId)
        {
            // var query = DbContext.Set<TEntity>().AsNoTracking();
            // return query.ToListAsync();
            
            var query = DbSet
                .Where(e => e.AgencyId == agencyId)
                // .Include(e => e.PayableItems)
                .AsNoTracking();

            return query;
        }

        public Task<List<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            var query = DbContext.Set<TEntity>()
                .AsNoTracking()
                .Where(predicate);

            return query.ToListAsync();
        }

        public Task<TEntity> SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = DbContext.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);
            
            return entity;
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            var entityEntry = DbContext.Set<TEntity>().Add(entity);
            await DbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRange(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().AddRange(entities);

            return DbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            var entityEntry = DbContext.Set<TEntity>().Update(entity);
            await DbContext.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task UpdateRange(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().UpdateRange(entities);

            return DbContext.SaveChangesAsync();
        }

        public Task Remove(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);

            return DbContext.SaveChangesAsync();
        }

        public Task RemoveRange(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().RemoveRange(entities);

            return DbContext.SaveChangesAsync();
        }
    }
}
