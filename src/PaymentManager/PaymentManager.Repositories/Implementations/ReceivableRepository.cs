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
        protected readonly PaymentDbContext _context;

        public ReceivableRepository(PaymentDbContext context)
        {
            _context = context;
        }

        public Task<ReceivableEntity> GetById(int agencyId, int id)
        {
            // TODO: need to use agencyId
            var query = _context.Receivables.AsQueryable()
                .Include(e => e.ReceivableItems)
                .AsNoTracking();

            return query.FirstOrDefaultAsync(payable => payable.Id == id);
        }

        public async Task<IQueryable<ReceivableEntity>> GetAll(int agencyId)
        {
            var query = _context.Receivables
                .Where(e => e.AgencyId == agencyId)
                .Include(e => e.ReceivableItems)
                .AsNoTracking();

            return query;
        }

        public async Task<IQueryable<ReceivableEntity>> Find(Expression<Func<ReceivableEntity, bool>> predicate)
        {
            var query = _context.Receivables
                .Where(predicate)
                .AsNoTracking();

            return query;
        }

        public async Task<ReceivableEntity> SingleOrDefault(Expression<Func<ReceivableEntity, bool>> predicate)
        {
            var entity = _context.Receivables
                .AsNoTracking()
                .SingleOrDefault(predicate);

            return entity;
        }

        public async Task<ReceivableEntity> Add(ReceivableEntity entity)
        {
            var entityEntry = _context.Receivables.Add(entity);

            await _context.SaveChangesAsync();

            return entityEntry.Entity;
        }

        public Task AddRange(List<ReceivableEntity> entities)
        {
            _context.Receivables.AddRange(entities);

            return _context.SaveChangesAsync();
        }

        public async Task<ReceivableEntity> Update(ReceivableEntity entity)
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

            return await GetById(entity.AgencyId, entity.Id);
        }

        public Task Remove(ReceivableEntity entity)
        {
            if (entity.PaidAmount > 0)
            {
                // Revisit
                entity.Status = PaymentStatus.Canceled;
                _context.Receivables.Update(entity);
            }
            else
            {
                _context.Receivables.Remove(entity);
            }

            return _context.SaveChangesAsync();
        }

        public Task RemoveRange(List<ReceivableEntity> entities)
        {
            var toRemove = entities.Where(e => e.PaidAmount == 0);
            _context.Receivables.RemoveRange(toRemove);

            var toUpdate = entities.Where(e => e.PaidAmount > 0);
            foreach (var entity in toUpdate)
            {
                // Revisit
                entity.Status = PaymentStatus.Canceled;
            }
            _context.Receivables.UpdateRange(toUpdate);

            return _context.SaveChangesAsync();
        }

        public Task UpdateRange(List<PayableEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}