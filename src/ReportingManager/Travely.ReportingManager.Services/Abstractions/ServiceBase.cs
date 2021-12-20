using AutoMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Travely.ReportingManager.Services.Extensions;
using Travely.Services.Common.Models;

namespace Travely.ReportingManager.Services.Abstractions
{
    public abstract class ServiceBase
    {
        protected ServiceBase(ILogger logger, IMapper mapper)
        {
            Logger = logger;
            Mapper = mapper;
        }

        protected ILogger Logger { get; }
        protected IMapper Mapper { get; }

        protected IQueryable<T> BuildFilters<T>(IQueryable<T> query, ICollection<FilteringModel> filters)
        {
            if (filters?.Count == 0)
                return query;

            var filterExpression = ExpressionHelper.BuildFilter<T>(filters);
            return query.Where(filterExpression);
        }

        protected IQueryable<T> BuildOrderings<T>(IQueryable<T> query, ICollection<OrderingModel> orderings)
        {
            if (orderings?.Count == 0)
                return query;

            var builder = ExpressionHelper.BuildOrderingFunc<T>(orderings);
            return builder.Invoke(query);
        }

        protected IQueryable<T> BuildPaging<T>(IQueryable<T> query, PagingModel pagingingBaseModel)
        {
            if (pagingingBaseModel==null)
                return query;

            return query.Skip(pagingingBaseModel.From).Take(pagingingBaseModel.Count);
        }
    }
}
