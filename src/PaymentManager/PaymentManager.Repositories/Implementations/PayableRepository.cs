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
    public class PayableRepository : IPaymentRepository<PayableEntity>
    {
        protected readonly PaymentDbContext _context;

        public PayableRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public Task<PayableEntity> GetById(int agencyId, int id)
        {
            // TODO: need to use agencyId
            var query = _context.Payables.AsQueryable()
                .Include(e => e.PayableItems)
                .AsNoTracking();

            return query.FirstOrDefaultAsync(payable => payable.Id == id);
        }

        public async Task<IQueryable<PayableEntity>> GetAll(int agencyId)
        {
            var query = _context.Payables
                .Where(e => e.AgencyId == agencyId)
                .Include(e => e.PayableItems)
                .AsNoTracking();

            return query;
        }

        public async Task<IQueryable<PayableEntity>> Find(Expression<Func<PayableEntity, bool>> predicate)
        {
            var query = _context.Payables
                .Where(predicate)
                .AsNoTracking();

            return query;
        }

        public async Task<PayableEntity> SingleOrDefault(Expression<Func<PayableEntity, bool>> predicate)
        {
            var entity = _context.Payables
                .AsNoTracking()
                .SingleOrDefault(predicate);

            return entity;
        }

        public async Task<PayableEntity> Add(PayableEntity entity)
        {
            var entityEntry = _context.Payables.Add(entity);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRange(List<PayableEntity> entities)
        {
            _context.Payables.AddRange(entities);

            return _context.SaveChangesAsync();
        }

        public async Task<PayableEntity> Update(PayableEntity entity)
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

            return await GetById(entity.AgencyId, entity.Id);
        }

        public Task Remove(PayableEntity entity)
        {
            if (entity.PaidAmount > 0)
            {
                // Revisit
                entity.Status = PaymentStatus.Canceled;
                _context.Payables.Update(entity);
            }
            else
            {
                _context.Payables.Remove(entity);
            }

            return _context.SaveChangesAsync();
        }

        public Task RemoveRange(List<PayableEntity> entities)
        {
            var toRemove = entities.Where(e => e.PaidAmount == 0);
            _context.Payables.RemoveRange(toRemove);

            var toUpdate = entities.Where(e => e.PaidAmount > 0);
            foreach (var entity in toUpdate)
            {
                // Revisit
                entity.Status = PaymentStatus.Canceled;
            }
            _context.Payables.UpdateRange(toUpdate);

            return _context.SaveChangesAsync();
        }

        public Task UpdateRange(List<PayableEntity> entities)
        {
            _context.Payables.UpdateRange(entities);

            return _context.SaveChangesAsync();
        }
    }
}
