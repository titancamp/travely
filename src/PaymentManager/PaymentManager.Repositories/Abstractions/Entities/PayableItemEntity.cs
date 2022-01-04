using PaymentManager.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentManager.Repositories.Entities
{
    public class PayableItemEntity
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public PayableEntity Invoice { get; set; }

        public string InvoiceId { get; set; }

        [Required]
        public decimal PaidAmount { get; set; }

        [Required]
        public DateTime PaymentDate { get; set; }

        [Required]
        public PaymentType PaymentType { get; set; }

        public string Note { get; set; }

        //public AttachmentEntity Attachment { get; set; }
    }
}
