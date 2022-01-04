using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories
{
    public interface IPayableRepository
    {
        Task<PayableEntity> GetById(int agencyId, int id);
        Task<IQueryable<PayableEntity>> GetAll(int agencyId);
        Task<IQueryable<PayableEntity>> Find(Expression<Func<PayableEntity, bool>> predicate);
        Task<PayableEntity> SingleOrDefault(Expression<Func<PayableEntity, bool>> predicate);
        Task<PayableEntity> Add(PayableEntity entity);
        Task AddRange(List<PayableEntity> entities);
        Task<PayableEntity> Update(PayableEntity entity);
        Task Remove(PayableEntity entity);
        Task RemoveRange(List<PayableEntity> entities);
    }
}
