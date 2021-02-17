using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Travely.ServiceManager.Abstraction.Models.Db
{
    public class ActivityType
    {
        public long Id { get; set; }
        [MaxLength(256)]
        public string Name { get; set; } = null!;
        public long AgencyId { get; set; }

        public virtual ICollection<Activity> Activities { get; set; }
    }
}

