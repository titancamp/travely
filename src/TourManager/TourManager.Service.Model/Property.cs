using System.Collections.Generic;
using TourManager.CommonTypes;

namespace TourManager.Service.Model
{
	public class Property
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Address { get; set; }
		public string ContactName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public string Website { get; set; }
		public int? Stars { get; set; }
		public PropertyOption PropertyType { get; set; }
		public List<string> Files { get; set; }
	}
}