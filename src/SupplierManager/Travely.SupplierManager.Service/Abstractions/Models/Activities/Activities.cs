using System;
using System.Collections.Generic;

namespace Travely.SupplierManager.Service.Models
{
    public class Activities
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public bool IsDeleted { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public List<Attribute> Attributes { get; set; }
        public int Duration { get; set; }
        public string Notes { get; set; }
        public decimal Cost { get; set; }
        public DateTime SignDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public List<Attachment> Attachments { get; set; }
    }
}