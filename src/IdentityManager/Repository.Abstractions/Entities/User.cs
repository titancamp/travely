using System;
using System.Collections.Generic;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
