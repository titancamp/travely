using Microsoft.EntityFrameworkCore;
using PaymentManager.Repositories.DbContexts;
using PaymentManager.Repositories.Entities;
using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories
{
    public class ReceivableRepository : IPaymentRepository<ReceivableEntity>
    {
        private readonly PaymentDbContext _context;

        public ReceivableRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public Task<ReceivableEntity> GetByIdAsync(int agencyId, int id)
        {
            var query = _context.Receivables
                .Where(e => e.AgencyId == agencyId)
                .Include(e => e.ReceivableItems)
                .AsNoTracking();

            return query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<ReceivableEntity> GetAll(int agencyId, bool includeItems)
        {
            var query = _context.Receivables
                .Where(e => e.AgencyId == agencyId);

            if (includeItems)
            {
                query = query.Include(e => e.ReceivableItems);
            }

            query = query.AsNoTracking();

            return query;
        }

        public IQueryable<ReceivableEntity> Find(Expression<Func<ReceivableEntity, bool>> predicate)
        {
            var query = _context.Receivables
                .Where(predicate)
                .AsNoTracking();

            return query;
        }

        public ReceivableEntity SingleOrDefault(Expression<Func<ReceivableEntity, bool>> predicate)
        {
            var entity = _context.Receivables
                .AsNoTracking()
                .SingleOrDefault(predicate);

            return entity;
        }

        public async Task<ReceivableEntity> AddAsync(ReceivableEntity entity)
        {
            var entityEntry = _context.Receivables.Add(entity);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRangeAsync(List<ReceivableEntity> entities)
        {
            _context.Receivables.AddRange(entities);

            return _context.SaveChangesAsync();
        }

        public async Task<ReceivableEntity> UpdateAsync(ReceivableEntity entity)
        {
            foreach (var item in entity.ReceivableItems)
            {
                _context.ReceivableItems.Update(item);
            }
            // Need a way to remove
            var query = _context.ReceivableItems
                .Where(i => i.Receivable == entity)
                .AsNoTracking();

            foreach (var item in query)
            {
                if (_context.Entry(item).State == EntityState.Detached)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
            }

            var updated = _context.Receivables.Update(entity);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(entity.AgencyId, entity.Id);
        }
    }
}