using System.Collections.Generic;
using TourManager.CommonTypes;

namespace TourManager.Service.Model
{
	public class Activity
	{
		public int Id { get; set; }
		public string ActivityName { get; set; }
		public string Address { get; set; }
		public string ContactName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public ActivityOption ActivityType { get; set; }
		public List<string> Files { get; set; }
	}
}