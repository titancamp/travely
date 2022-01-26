using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.Entities
{
    public class PayableEntity
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int TourId { get; set; }
        public string TourName { get; set; }
        public TourStatus TourStatus { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public decimal PlannedCost { get; set; }
        public decimal? ActualCost { get; set; }
        public decimal? Difference { get; set; }
        public decimal PaidAmount { get; set; }
        public decimal? Remaining { get; set; }
        public string Currency { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastModified { get; set; } = DateTime.Now;
        public DateTime? DueDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public PaymentType? PaymentType { get; set; }
        public bool HasAttachment { get; set; }
        public ICollection<PayableItemEntity> PayableItems { get; set; }
        public string Note { get; set; }
    }
}