using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.ClientManager.Abstraction.Entity
{
    [Table("Tourist")]
    public class Tourist : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PlaceOfBirth { get; set; }
        public string? PassportNumber { get; set; }
        public string? IssuedBy { get; set; }
        public DateTime? IssuedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public int AgencyId { get; set; }

        public virtual ICollection<Preference> Preferences { get; set; }
    }
}
