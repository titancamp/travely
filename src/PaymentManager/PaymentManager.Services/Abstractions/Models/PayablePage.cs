using AutoMapper;
using PaymentManager.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Services.Models
{
    public class PayablePage
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public decimal TotalPlannedCost { get; set; }
        public decimal TotalActualCost { get; set; }
        public decimal TotalDifference { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalRemaining { get; set; }
        public List<PayableRead> Items { get; set; }

        public static PayablePage GetPayablePage(IQueryable<PayableEntity> query, IMapper mapper, int page, int size)
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

            foreach (var item in query.ToList())
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
    }
}
