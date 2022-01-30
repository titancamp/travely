using System;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Reflection;
using System.Text;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Repository.Filters
{
    public static class Filters
    {
        public static IQueryable<TEntity> Filter<TEntity>(this IQueryable<TEntity> query, Filter<TEntity> filter)
            where TEntity : class, IEntity
        {
            query = Order(query, filter.Order);
            return filter.Apply(query);
        }
        
        public static IQueryable<TEntity> Order<TEntity>(IQueryable<TEntity> entities, string orderBy)
            where TEntity : class, IEntity
        {
            if (!entities.Any() || string.IsNullOrWhiteSpace(orderBy))
            {
                return entities;
            }

            var orderParams = orderBy.Trim().Split(',');
            var propertyInfos = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var orderQueryBuilder = new StringBuilder();
            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                {
                    continue;
                }
                string propertyFromQueryName = param.Split(" ")[0];
                
                var objectProperty = propertyInfos.FirstOrDefault(pi =>
                    pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

                if (objectProperty == null)
                {
                    continue;
                }
                string sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
                orderQueryBuilder.Append($"{objectProperty.Name} {sortingOrder}, ");
            }

            string orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
            return entities.OrderBy(orderQuery);
        }
    }
}