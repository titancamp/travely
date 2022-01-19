using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Travely.SupplierManager.API.Models;
using Travely.SupplierManager.Repository.Entities;

namespace Travely.SupplierManager.Service.Models
{
    public class SupplierPage<TModel>
    {
        public int CurrentPage { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages { get; private set; }
        
        public List<TModel> Items { get; private set; }
        
        public static SupplierPage<TModel> GetPagedSuppliers<TEntity>(IQueryable<TEntity> query, IMapper mapper, SupplierQueryParams parameters)
            where TEntity : class, IEntity
        {
            int currPage = parameters.PageNumber;
            int pageSize = parameters.Size;
            int totalCount = query.Count();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            
            var entities = query
                // .OrderBy(e => e.Id)
                .Skip((currPage - 1) * pageSize)
                .Take(pageSize)
                .ToList();
            
            var suppliers = mapper.Map<List<TModel>>(entities);

            return new SupplierPage<TModel>
            {
                CurrentPage = currPage,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                
                Items = suppliers
            };
        }
        
        
    }
}