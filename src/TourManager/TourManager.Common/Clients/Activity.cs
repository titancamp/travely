using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManager.Common.Clients
{
    public class Activity
    {
        /// <summary>
        /// Id is nullable long - it can be null when frontend inserts new activity
        /// </summary>
        public long? Id { get; set; }
        public ActivityType Type { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public double Price { get; set; }
    }
}
