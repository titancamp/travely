using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Travely.ReportingManager.Services.Models.Base;

namespace Travely.ReportingManager.Services.Extensions
{
    public static class ExpressionHelper
    {
        public static Func<IQueryable<TSource>, IOrderedQueryable<TSource>> BuildOrderingFunc<TSource>(ICollection<OrderingBaseModel> orderings)
        {
            Expression result = Expression.Empty();

            ParameterExpression sourceParameterExpression = Expression.Parameter(typeof(IQueryable<>).MakeGenericType(typeof(TSource)), "source");
            ParameterExpression localParameterExpression = Expression.Parameter(typeof(TSource), "x");

            Type type = typeof(TSource);
            PropertyInfo[] typeProperties = type.GetProperties();

            int currentIndex = 1;
            foreach (var ordering in orderings)
            {
                PropertyInfo propertyInfo = typeProperties.FirstOrDefault(x => x.Name == ordering.FieldName);
                MemberExpression memberExpression = Expression.PropertyOrField(localParameterExpression, ordering.FieldName);
                LambdaExpression lambdaExpression = Expression.Lambda(memberExpression, localParameterExpression);

                Expression left;
                string methodName = "OrderBy";
                if (currentIndex == 1)
                {
                    methodName = ordering.IsDescending ? "OrderByDescending" : "OrderBy";
                    left = sourceParameterExpression;
                }
                else
                {
                    methodName = ordering.IsDescending ? "ThenByDescending" : "ThenBy";
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
        public static Expression<Func<T, bool>> BuildFilter<T>(ICollection<FilteringBaseModel> filters)
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
                var propertyInfo = typeProperties.FirstOrDefault(f => f.Name == filter.FieldName);
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

                            var stringContainsMethod = typeOfString.GetMethod("Contains", new Type[] { typeOfString });
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
