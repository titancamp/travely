using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Common.Clients
{
    public class ActivityType
    {
        // Id can be null when frontend search for activity type by activity type name or add a new type providing only name.
        public long? Id { get; set; }
        public string ActivityName { get; set; }
        public int AgencyId { get; set; }
    }
}
