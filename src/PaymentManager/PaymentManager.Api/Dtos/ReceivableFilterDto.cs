using System;
using System.Collections.Generic;
using PaymentManager.Shared;

namespace PaymentManager.Api.Dtos
{
    public class ReceivableFilterDto
    {
        public List<int> TourIds { get; set; }
        public List<string> PartnerNames { get; set; }
        public PaymentStatus? Status { get; set; }
        public RangeType<decimal> TotalAmount { get; set; }
        public RangeType<decimal> PaidAmount { get; set; }
        public RangeType<decimal> Remaining { get; set; }
        public RangeType<decimal> Rate { get; set; }
        public RangeType<DateTime> CreatedDate { get; set; }
        public RangeType<DateTime> DueDate { get; set; }
        public RangeType<DateTime> PaymentDate { get; set; }
        public PaymentType? Type { get; set; }
        public bool? HasAttachment { get; set; }
        public bool? InvoiceSent { get; set; }
        public string Currency { get; set; }
    }
}