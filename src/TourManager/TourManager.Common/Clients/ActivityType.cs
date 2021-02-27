using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Common.Clients
{
    public class ActivityType
    {
        public long? Id { get; set; }
        public string ActivityName { get; set; }
        public int AgencyId { get; set; }
    }
}
