using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Helpers
{
    public class PayableSearchHelper : ISearchHelper<PayableEntity>
    {
        public IQueryable<PayableEntity> ApplySearch(IQueryable<PayableEntity> query, string search)
        {
            if (!query.Any() || string.IsNullOrWhiteSpace(search))
            {
                return query; 
            }

            search = search.Trim().ToLower();
            var newQuery = query.Where(e =>
                e.TourId.ToString().Contains(search) || e.TourName.ToLower().Contains(search) ||
                e.SupplierName.ToLower().Contains(search));

            return newQuery;
        }
    }
}
