using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Helpers
{
    public interface ISearchHelper<TEntity>
    {
        IQueryable<TEntity> ApplySearch(IQueryable<TEntity> query, string search);
    }
}
