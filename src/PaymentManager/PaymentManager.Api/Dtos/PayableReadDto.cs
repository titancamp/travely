﻿using PaymentManager.Shared;
using System;
using System.Collections.Generic;

namespace PaymentManager.Api.Dtos
{
    public class PayableReadDto
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Currency { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? Difference { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? Remaining { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DueDate { get; set; }
        public PaymentType PaymentType { get; set; }
        public bool HasAttachment { get; set; }
    }
}
