using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class Agency
    {
        public Agency()
        {

        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string WebSite { get; set; }
        public string LogoFile { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
