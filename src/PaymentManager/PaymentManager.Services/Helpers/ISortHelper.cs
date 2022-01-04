using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Helpers
{
    public interface ISortHelper<TEntity>
    {
        IQueryable<TEntity> ApplySort(IQueryable<TEntity> entities, string orderBy);
    }
}
