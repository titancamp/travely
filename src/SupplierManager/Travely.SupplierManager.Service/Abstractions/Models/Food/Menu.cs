using System.Collections.Generic;

namespace Travely.SupplierManager.Service.Models
{
    public class Menu
    {
        public int Id { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<Tag> Tags { get; set; }
    }
}