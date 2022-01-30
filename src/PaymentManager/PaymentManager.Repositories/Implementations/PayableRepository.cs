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
using PaymentManager.Repositories.Extensions;
using PaymentManager.Repositories.Filters;
using PaymentManager.Repositories.Models;

namespace PaymentManager.Repositories
{
    public class PayableRepository : IPaymentRepository<PayableEntity>
    {
        private readonly PaymentDbContext _context;

        public PayableRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public Task<PayableEntity> GetByIdAsync(int agencyId, int id)
        {
            var query = _context.Payables
                .Where(e => e.AgencyId == agencyId)
                .Include(e => e.PayableItems)
                .AsNoTracking();

            return query.FirstOrDefaultAsync(e => e.Id == id);
        }

        public IQueryable<PayableEntity> GetAll(int agencyId, bool includeItems, PaymentQueryParameters parameters, IFilter<PayableEntity> filter)
        {
            var query = _context.Payables
                .Where(e => e.AgencyId == agencyId);

            query = query.Sort(parameters.OrderBy);

            query = query.Search(parameters.Search);

            query = query.Filter(filter);
            
            if (includeItems)
            { 
                query = query.Include(e => e.PayableItems);
            }

            query = query.AsNoTracking();

            return query;
        }

        public IQueryable<PayableEntity> Find(Expression<Func<PayableEntity, bool>> predicate)
        {
            var query = _context.Payables
                .Where(predicate)
                .AsNoTracking();

            return query;
        }

        public PayableEntity SingleOrDefault(Expression<Func<PayableEntity, bool>> predicate)
        {
            var entity = _context.Payables
                .AsNoTracking()
                .SingleOrDefault(predicate);

            return entity;
        }

        public async Task<PayableEntity> AddAsync(PayableEntity entity)
        {
            var entityEntry = _context.Payables.Add(entity);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRangeAsync(List<PayableEntity> entities)
        {
            _context.Payables.AddRange(entities);

            return _context.SaveChangesAsync();
        }

        public async Task<PayableEntity> UpdateAsync(PayableEntity entity)
        {
            foreach (var item in entity.PayableItems)
            {
                _context.PayableItems.Update(item);
            }
            // Need a way to remove
            var query = _context.PayableItems
                .Where(i => i.Payable == entity)
                .AsNoTracking();

            foreach (var item in query)
            {
                if (_context.Entry(item).State == EntityState.Detached)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
            }

            var updated = _context.Payables.Update(entity);
            await _context.SaveChangesAsync();

            return await GetByIdAsync(entity.AgencyId, entity.Id);
        }
    }
}
