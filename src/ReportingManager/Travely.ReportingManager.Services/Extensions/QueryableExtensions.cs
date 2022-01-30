using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Travely.Common;

namespace Travely.ReportingManager.Services.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> FilterBy<T>(this IQueryable<T> query, ICollection<FilteringModel> filters)
        {
            if (filters?.Count == 0)
                return query;

            var filterExpression = BuildFilter<T>(filters);
            return query.Where(filterExpression);
        }
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, ICollection<OrderingModel> orderings)
        {
            if (orderings?.Count == 0)
                return query;

            var builder = BuildOrderingFunc<T>(orderings);
            return builder.Invoke(query);
        }
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, PagingModel pagingingBaseModel)
        {
            if (pagingingBaseModel == null)
                return query;

            return query.Skip(pagingingBaseModel.From).Take(pagingingBaseModel.Count);
        }
        private static Func<IQueryable<TSource>, IOrderedQueryable<TSource>> BuildOrderingFunc<TSource>(ICollection<OrderingModel> orderings)
        {
            Expression result = Expression.Empty();

            ParameterExpression sourceParameterExpression = Expression.Parameter(typeof(IQueryable<>).MakeGenericType(typeof(TSource)), "source");
            ParameterExpression localParameterExpression = Expression.Parameter(typeof(TSource), "x");

            Type type = typeof(TSource);
            PropertyInfo[] typeProperties = type.GetProperties();

            int currentIndex = 1;
            foreach (var ordering in orderings)
            {
                PropertyInfo propertyInfo = typeProperties.FirstOrDefault(x => x.Name.Equals(ordering.FieldName, StringComparison.InvariantCultureIgnoreCase));
                MemberExpression memberExpression = Expression.PropertyOrField(localParameterExpression, ordering.FieldName);
                LambdaExpression lambdaExpression = Expression.Lambda(memberExpression, localParameterExpression);

                Expression left;
                string methodName = nameof(Queryable.OrderBy);
                if (currentIndex == 1)
                {
                    methodName = ordering.IsDescending ? nameof(Queryable.OrderByDescending) : nameof(Queryable.OrderBy);
                    left = sourceParameterExpression;
                }
                else
                {
                    methodName = ordering.IsDescending ? nameof(Queryable.ThenByDescending) : nameof(Queryable.ThenBy);
                    left = result;
                }
                result = Expression.Call(typeof(Queryable),
                                         methodName,
                                         new Type[] { type, propertyInfo.PropertyType },
                                         left, lambdaExpression
                                         );

                currentIndex++;
            }

            var lambda = Expression.Lambda<Func<IQueryable<TSource>, IOrderedQueryable<TSource>>>(result, sourceParameterExpression);
            return lambda.Compile();
        }
        private static Expression<Func<T, bool>> BuildFilter<T>(ICollection<FilteringModel> filters)
        {
            if (filters.Count == 0)
            {
                return (_) => true;
            }

            Expression finalFilter = Expression.Constant(false); // (_) => false;

            var type = typeof(T);
            var typeProperties = type.GetProperties();
            var typeOfString = typeof(string);

            var parameterExpression = Expression.Parameter(type, "x");
            foreach (var filter in filters)
            {
                var propertyInfo = typeProperties.FirstOrDefault(f => f.Name.Equals(filter.FieldName, StringComparison.InvariantCultureIgnoreCase));
                if (propertyInfo != null)
                {
                    var memberExpression = Expression.Property(parameterExpression, propertyInfo.Name);
                    var filterValueExpression = GetValueExpression(propertyInfo.PropertyType, filter.Value);

                    switch (filter.Type)
                    {
                        case FilteringOperationType.Equals:
                            MethodInfo equalsMethodInfo = FindOptimalEqualsMethod(propertyInfo.PropertyType);
                            var equalsCallExpression = Expression.Call(instance: memberExpression, method: equalsMethodInfo, arguments: filterValueExpression);
                            finalFilter = Expression.Or(finalFilter, equalsCallExpression);
                            break;
                        case FilteringOperationType.Contains:
                            if (!IsString(propertyInfo))
                                break;

                            var stringContainsMethod = typeOfString.GetMethod(nameof(string.Contains), new Type[] { typeOfString });
                            var containsCallExpression = Expression.Call(instance: memberExpression, method: stringContainsMethod, arguments: filterValueExpression);

                            finalFilter = Expression.Or(finalFilter, containsCallExpression);

                            break;
                        default:
                            break;
                    }
                }
            }

            return Expression.Lambda<Func<T, bool>>(finalFilter, parameterExpression);
        }
        private static bool IsInteger(PropertyInfo pInfo)
        {
            return pInfo.PropertyType == typeof(int);
        }
        private static bool IsString(PropertyInfo pInfo)
        {
            return pInfo.PropertyType == typeof(string);
        }
        private static ConstantExpression GetValueExpression(Type type, string valueString)
        {
            if (type == typeof(string))
                return Expression.Constant(valueString, typeof(string));
            else if (type == typeof(int))
                return Expression.Constant(Convert.ToInt32(valueString), typeof(int));

            throw new NotSupportedException();
        }
        private static MethodInfo FindOptimalEqualsMethod(Type propertyType)
        {
            MethodInfo equalsMethodInfo;

            // optimization for struct types, to avoid boxing 
            if (propertyType.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEquatable<>)))
            {
                equalsMethodInfo = propertyType.GetMethod("Equals", new Type[] { propertyType });
            }
            else
            {
                equalsMethodInfo = propertyType.GetMethod("Equals", new Type[] { typeof(object) });
            }

            return equalsMethodInfo;
        }
    }
}
