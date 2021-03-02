using System;
using System.ComponentModel.DataAnnotations;

namespace Travely.ServiceManager.Abstraction.Models.Db
{
    public class Activity
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string ContactName { get; set; } = null!;
        public string EmailAddress { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Website { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; } = null!;
        public string Notes { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public long? ChangeUser { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public long ActivityTypeId { get; set; }
    }
}
