using System;
using System.Collections.Generic;

namespace TourManager.Repository.Entities
{
    /// <summary>
    /// The client entity
    /// </summary>
    public class ClientEntity
    {
        /// <summary>
        /// The client entity id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The client agency id
        /// </summary>
        public int AgencyId { get; set; }

        /// <summary>
        /// The client external id
        /// </summary>
        public int ExternalId { get; set; }

        /// <summary>
        /// The tour clients collection
        /// </summary>
        public ICollection<TourClientEntity> TourClients { get; set; }

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
        public string Phone { get; set; }

        /// <summary>
        /// The client email address
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The client date of birth
        /// </summary>
        public DateTime DateOfBirth { get; set; }

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
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// The client passport expiration date
        /// </summary>
        public DateTime ExpireDate { get; set; }

        /// <summary>
        /// The notes about the client
        /// </summary>
        public string Notes { get; set; }
    }
}