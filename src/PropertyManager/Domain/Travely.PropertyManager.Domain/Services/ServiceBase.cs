using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Travely.PropertyManager.Domain.Entities;
using Travely.PropertyManager.Domain.Entities.Base;
using Travely.PropertyManager.Domain.Extensions;

namespace Travely.PropertyManager.Domain.Services
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

        protected IQueryable<T> BuildFilters<T>(IQueryable<T> query, ICollection<FilteringBaseModel> filters)
        {
            var filterExpression = ExpressionHelper.BuildFilter<T>(filters);

            return query.Where(filterExpression);
        }

        protected IQueryable<Property> BuildSortings(IQueryable<Property> query, ICollection<SortingBaseModel> sortings)
        {
            throw new NotImplementedException();
        }
    }
}
