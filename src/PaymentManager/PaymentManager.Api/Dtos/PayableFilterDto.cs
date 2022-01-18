using System;
using System.Collections.Generic;
using PaymentManager.Shared;

namespace PaymentManager.Api.Dtos
{
    public class PayableFilterDto
    {
        public List<int> TourIds { get; set; }
        public List<int> SupplierIds { get; set; }
        public PaymentStatus? Status { get; set; }
        public RangeType<decimal> PlannedCost { get; set; }
        public RangeType<decimal> ActualCost { get; set; }
        public RangeType<decimal> Difference { get; set; }
        public RangeType<decimal> Remaining { get; set; }
        public RangeType<DateTime> CreatedDate { get; set; }
        public RangeType<DateTime> DueDate { get; set; }
        public RangeType<DateTime> PaymentDate { get; set; }
        public PaymentType? Type { get; set; }
        public bool? HasAttachment { get; set; }
        public string Currency { get; set; }
    }
}