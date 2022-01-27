using System;
using System.Collections.Generic;
using System.Linq;
using PaymentManager.Repositories.Entities;
using PaymentManager.Shared;

namespace PaymentManager.Repositories.Filters
{
    public class ReceivableFilter : IFilter<ReceivableEntity>
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

        public IQueryable<ReceivableEntity> ApplyFilter(IQueryable<ReceivableEntity> query)
        {
            if (TourIds.Count != 0)
            {
                query = query.Where(e => TourIds.Any(i => i == e.TourId));
            }
            if (PartnerNames.Count != 0)
            {
                query = query.Where(e => PartnerNames.Any(i => i == e.PartnerName)); // later replace with partner id
            }
            if (Status != null)
            {
                query = query.Where(e => e.Status == Status);
            }
            if (TotalAmount != null)
            {
                query = query.Where(e => e.TotalAmount >= TotalAmount.Min && e.TotalAmount <= TotalAmount.Max);
            }
            if (PaidAmount != null)
            {
                query = query.Where(e => e.PaidAmount >= PaidAmount.Min && e.PaidAmount <= PaidAmount.Max);
            }
            if (Remaining != null)
            {
                query = query.Where(e => e.Remaining >= Remaining.Min && e.Remaining <= Remaining.Max);
            }
            if (Rate != null)
            {
                query = query.Where(e => e.Rate >= Rate.Min && e.Rate <= Rate.Max);
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
            if (InvoiceSent != null)
            {
                query = query.Where(e => e.InvoiceSent == InvoiceSent);
            }
            if (!string.IsNullOrEmpty(Currency))
            {
                query = query.Where(e => e.Currency == Currency);
            }
            return query;
        }
    }
}