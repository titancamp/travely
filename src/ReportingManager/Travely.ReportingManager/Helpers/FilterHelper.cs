using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Travely.PropertyManager.API;

namespace Travely.ReportingManager.Helpers
{

    public interface IFilter<T>
    {
        Expression<Func<T, bool>> GetPredicate(FilteringBaseModel filter);
        void CreateMap(string name, Expression<Func<T, object>> expression);
    }

    public class Filter<T> : IFilter<T>
    {
        private Dictionary<string, Expression<Func<T, object>>> _dictionary;
        public Filter()
        {
            _dictionary = new Dictionary<string, Expression<Func<T, object>>>();
        }

        public void CreateMap(string name, Expression<Func<T, object>> expression)
        {
            _dictionary.Add(name, expression);
        }

        public Expression<Func<T, bool>> GetPredicate(FilteringBaseModel filter)
        {
            if (_dictionary.ContainsKey(filter.FieldName))
            {
                switch (filter.Type)
                {
                    case FilteringOperationType.Equals:
                        return Expression.Lambda<Func<T, bool>>(Expression.Equal(_dictionary[filter.FieldName].Body, Expression.Constant(filter.Value)), _dictionary[filter.FieldName].Parameters);
                    case FilteringOperationType.Contains:
                        {
                            var method = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });
                            return Expression.Lambda<Func<T, bool>>(Expression.Call(_dictionary[filter.FieldName].Body, method, Expression.Constant(filter.Value)), _dictionary[filter.FieldName].Parameters);
                        }
                }
            }

            return p => true;
        }
    }

    public class FilterBaseModel
    {
        public FilterBaseModel(string fieldName, string type, string value)
        {
            FieldName = fieldName;
            Type = type;
            Value = value;
        }

        public string FieldName { get; }
        public string Type { get; }
        public string Value { get; }
    }

    public static class FilterExtensions
    {
        public static Expression<Func<T, bool>> ToPredicate<T>(this IFilter<T> source, ICollection<FilteringBaseModel> filters)
        {
            Expression<Func<T, bool>> expression = p => true;

            foreach (var filter in filters)
            {
                expression = Expression.Lambda<Func<T, bool>>(Expression.And(expression.Body, source.GetPredicate(filter).Body), expression.Parameters);
            }

            return expression;
        }
    }

}
