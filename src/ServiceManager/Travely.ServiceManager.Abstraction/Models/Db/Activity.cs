using System;

namespace Travely.ServiceManager.Abstraction.Models.Db
{
    public class Activity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public decimal? Price { get; set; }
        public string Currency { get; set; }
        public string Notes { get; set; }
        public DateTime ChangeDate { get; set; }
        public long ChangeUser { get; set; }

        public ActivityType ActivityType { get; set; }
        public long ActivityTypeId { get; set; }
    }
}
