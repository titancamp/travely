using System;
using System.Collections.Generic;

namespace Travely.ServiceManager.Abstraction.Models.Db
{
    public class ActivityType
    {
        public long Id { get; set; }
        public string ActivityName { get; set; }
        public long AgencyId { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
