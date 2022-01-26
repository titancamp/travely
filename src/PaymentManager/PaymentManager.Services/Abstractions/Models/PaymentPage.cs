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
    public class PaymentPage<TModel>
    {
        public int TotalCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public List<TModel> Items { get; set; }
    }
}
