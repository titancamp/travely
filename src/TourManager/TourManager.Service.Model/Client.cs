using FluentValidation;
using System;

namespace TourManager.Service.Model
{
	/// <summary>
	/// The client validator
	/// </summary>
	public class ClientValidator : AbstractValidator<Client>
	{
		/// <summary>
		/// Create new instance of client validator
		/// </summary>
		public ClientValidator()
		{
			RuleFor(client => client.FirstName).NotEmpty().WithMessage("The client first name field is requiered!");
			RuleFor(client => client.LastName).NotEmpty().WithMessage("The client last name field is requiered!");
			RuleFor(client => client.PhoneNumber).NotEmpty().WithMessage("The client phone field is requiered!");
			RuleFor(client => client.Email).NotEmpty().WithMessage("The client email field is requiered!")
				.EmailAddress().WithMessage("The client email address is not valid!");
			RuleFor(client => client.Notes).NotEmpty().WithMessage("The client notes field is requiered!");
		}
	}

	/// <summary>
	/// The tour client model
	/// </summary>
	public class Client
	{
		/// <summary>
		/// The client id
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// The client first name
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// The client last name
		/// </summary>
		public string LastName { get; set; }

		/// <summary>
		/// The client phone number
		/// </summary>
		public string PhoneNumber { get; set; }

		/// <summary>
		/// The client email address
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// The client date of birth
		/// </summary>
		public DateTime? DateOfBirth { get; set; }

		/// <summary>
		/// The client birthplace
		/// </summary>
		public string PlaceOfBirth { get; set; }

		/// <summary>
		/// The client passport number
		/// </summary>
		public string PassportNumber { get; set; }

		/// <summary>
		/// The client passport issued by
		/// </summary>
		public string IssuedBy { get; set; }

		/// <summary>
		/// The client passport issue date
		/// </summary>
		public DateTime? IssuedDate { get; set; }

		/// <summary>
		/// The client passport expiration date
		/// </summary>
		public DateTime? ExpireDate { get; set; }

		/// <summary>
		/// The notes about the client
		/// </summary>
		public string Notes { get; set; }

		/// <summary>
		/// Shows whether the customer is main or not.
		/// </summary>
		public bool IsMain { get; set; }
	}
}