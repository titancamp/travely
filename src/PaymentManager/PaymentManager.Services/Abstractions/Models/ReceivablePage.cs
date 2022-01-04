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
    public class ReceivablePage
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public List<ReceivableRead> Items { get; set; }

        public static ReceivablePage GetReceivablePage(IQueryable<ReceivableEntity> query, IMapper mapper, int page, int size)
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
