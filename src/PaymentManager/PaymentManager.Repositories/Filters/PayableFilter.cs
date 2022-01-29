using System;
using System.Collections.Generic;
using System.Linq;
using PaymentManager.Repositories.Entities;
using PaymentManager.Shared;

namespace PaymentManager.Repositories.Filters
{
    public class PayableFilter : IFilter<PayableEntity>
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

        public IQueryable<PayableEntity> ApplyFilter(IQueryable<PayableEntity> query)
        {
            if (TourIds.Count != 0)
            {
                query = query.Where(e => TourIds.Any(i => i == e.TourId));
            }
            if (SupplierIds.Count != 0)
            {
                query = query.Where(e => SupplierIds.Any(i => i == e.SupplierId));
            }
            if (Status != null)
            {
                query = query.Where(e => e.Status == Status);
            }
            if (PlannedCost != null)
            {
                query = query.Where(e => e.PlannedCost >= PlannedCost.Min && e.PlannedCost <= PlannedCost.Max);
            }
            if (ActualCost != null)
            {
                query = query.Where(e => e.ActualCost >= ActualCost.Min && e.ActualCost <= ActualCost.Max);
            }
            if (Difference != null)
            {
                query = query.Where(e => e.Difference >= Difference.Min && e.Difference <= Difference.Max);
            }
            if (Remaining != null)
            {
                query = query.Where(e => e.Remaining >= Remaining.Min && e.Remaining <= Remaining.Max);
            }
            if (CreatedDate != null)
            {
                query = query.Where(e => e.CreatedAt >= CreatedDate.Min && e.CreatedAt <= CreatedDate.Max);
            }
            if (DueDate != null)
            {
                query = query.Where(e => e.DueDate >= DueDate.Min && e.DueDate <= DueDate.Max);
            }
            if (PaymentDate != null)
            {
                query = query.Where(e => e.PaymentDate >= PaymentDate.Min && e.PaymentDate <= PaymentDate.Max);
            }
            if (Type != null)
            {
                query = query.Where(e => e.PaymentType == Type);
            }
            if (HasAttachment != null)
            {
                query = query.Where(e => e.HasAttachment == HasAttachment);
            }
            if (!string.IsNullOrEmpty(Currency))
            {
                query = query.Where(e => e.Currency == Currency);
            }
            return query;
        }
    }
}