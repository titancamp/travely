using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.IdentityManager.Repository.Model.AppEntities
{
    public class User
    {
        public User()
        {
            Employees = new HashSet<Employee>();
            Organizations = new HashSet<Agency>();
        }

        public int Id { get; set; }
        public DateTime? LastLogin { get; set; }
        public int RoleId { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Agency> Organizations { get; set; }
    }
}
