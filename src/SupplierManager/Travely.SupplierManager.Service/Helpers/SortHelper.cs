using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using System;
using System.Linq;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Service.Helpers
{
    public class SortHelper<TEntity> : ISortHelper<TEntity>
        where TEntity : class, IEntity
    {
        public IQueryable<TEntity> Order(IQueryable<TEntity> entities, string orderBy)
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