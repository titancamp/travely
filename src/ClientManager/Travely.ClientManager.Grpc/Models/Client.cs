using System;

namespace Travely.ClientManager.Grpc.Models
{
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
        /// The external identifier
        /// </summary>
        public int ExternalId { get; set; }

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