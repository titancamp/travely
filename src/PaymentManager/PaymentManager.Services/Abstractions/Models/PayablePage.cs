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
    public class PayablePage : PaymentPage<PayableRead>
    {
        public decimal TotalPlannedCost { get; set; }
        public decimal TotalActualCost { get; set; }
        public decimal TotalDifference { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalRemaining { get; set; }
    }
}
