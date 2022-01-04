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
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public int AgencyId { get; set; }

        [Required]
        public int TourId { get; set; }

        [Required]
        public string TourName { get; set; }

        [Required]
        public TourStatus TourStatus { get; set; }

        [Required]
        public int SupplierId { get; set; }

        [Required]
        public string SupplierName { get; set; }

        [Required]
        public decimal PlannedCost { get; set; }

        public decimal? ActualCost { get; set; }

        public decimal? Difference { get; set; }

        public decimal Paid { get; set; }

        public decimal? Remaining { get; set; }

        [Required]
        public string Currency { get; set; }

        public PaymentStatus Status { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime LastModified { get; set; } = DateTime.Now;

        public DateTime? DueDate { get; set; }

        public ICollection<PayableItemEntity> PayableItems { get; set; }

        //public override string ToString()
        //{
        //    return $"{Id} {AgencyId} {Tour.RealId} {Tour.Name} {Supplier.RealId} {Supplier.Name} {Tour.Status} {PlannedCost} {ActualCost}";
        //}
    }
}
