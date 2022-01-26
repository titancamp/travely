using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PaymentManager.Repositories.Entities;
using PaymentManager.Services.Models;

namespace PaymentManager.Extensions.DependencyInjection.Extensions
{
    public static class PaginationExtension
    {
        public static PayablePage GetPayablePage(this IQueryable<PayableEntity> query, IMapper mapper, int page, int size)
        {
            int currentPage = page;
            int pageSize = size;
            int totalCount = query.Count();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            decimal totalPlannedCost = 0;
            decimal totalActualCost = 0;
            decimal totalDifference = 0;
            decimal totalPaid = 0;
            decimal totalRemaining = 0;

            foreach (var item in query)
            {
                totalPlannedCost += item.PlannedCost;
                totalActualCost += item.ActualCost.GetValueOrDefault(0);
                totalDifference += item.Difference.GetValueOrDefault(0);
                totalPaid += item.PaidAmount;
                totalRemaining += item.Remaining.GetValueOrDefault(0);
            }
            query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);

            var entities = query.ToList();
            var items = mapper.Map<List<PayableRead>>(entities);

            return new PayablePage
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                TotalPlannedCost = totalPlannedCost,
                TotalActualCost = totalActualCost,
                TotalDifference = totalDifference,
                TotalPaid = totalPaid,
                TotalRemaining = totalRemaining,
                Items = items
            };
        }
        
        public static ReceivablePage GetReceivablePage(this IQueryable<ReceivableEntity> query, IMapper mapper, int page, int size)
        {
            int currentPage = page;
            int pageSize = size;
            int totalCount = query.Count();
            int totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            query = query.Skip((currentPage - 1) * pageSize).Take(pageSize);

            var entities = query.ToList();
            var items = mapper.Map<List<ReceivableRead>>(entities);

            return new ReceivablePage
            {
                CurrentPage = currentPage,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items
            };
        }
    }
}