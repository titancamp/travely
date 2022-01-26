using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Text;
using PaymentManager.Repositories.Entities;
using PaymentManager.Repositories.Filters;

namespace PaymentManager.Repositories.Extensions
{
    public static class RepositoryExtension
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, IFilter<TEntity> filter)
        {
            return filter.ApplyFilter(query);
        }

        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> query, string orderByQueryString)
        {
            if (!query.Any() || string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return query;
            }
            var orderParams = orderByQueryString.Trim().Split(',');
            var propertyInfos = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;
                var propertyFromQueryName = param.Split(" ")[0];
                var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
                if (objectProperty == null)
                    continue;
                var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }
            var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            if (string.IsNullOrWhiteSpace(orderQuery))
            {
                orderQuery = "CreatedAt descending";
            }
            return query.OrderBy(orderQuery);
        }
        
        public static IQueryable<PayableEntity> Search(this IQueryable<PayableEntity> query, string search)
        {
            if (query.Any() && !string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim().ToLower();
                query = query.Where(e =>
                    e.TourId.ToString().Contains(search) || e.TourName.ToLower().Contains(search) ||
                    e.SupplierName.ToLower().Contains(search));
            }
            return query;
        }
        
        public static IQueryable<ReceivableEntity> Search(this IQueryable<ReceivableEntity> query, string search)
        {
            if (query.Any() && !string.IsNullOrWhiteSpace(search))
            {

                search = search.Trim().ToLower();
                query = query.Where(e =>
                    e.TourId.ToString().Contains(search) || e.TourName.ToLower().Contains(search) ||
                    e.PartnerName.ToLower().Contains(search));
            }
            return query;
        }
    }
}