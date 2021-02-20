using System;

namespace TourManager.Service.Model
{
	public class Client
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Phone { get; set; }
		public string Email { get; set; }
		public DateTime? DateOfBirth { get; set; }
		public string PlaceOfBirth { get; set; }
		public string PassportNumber { get; set; }
		public string IssuedBy { get; set; }
		public DateTime? IssueDate { get; set; }
		public DateTime? ExpireDate { get; set; }
		public string Notes { get; set; }
	}
}