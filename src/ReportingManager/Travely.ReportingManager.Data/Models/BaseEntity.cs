using System;

namespace Travely.ReportingManager.Data.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate
        {
            get
            {
                return this.createdDate.HasValue
                   ? this.createdDate.Value
                   : DateTime.Now;
            }

            set { this.createdDate = value; }
        }

        private DateTime? createdDate = null;
        public DateTime? ModifiedDate { get; set; }
    }
}
