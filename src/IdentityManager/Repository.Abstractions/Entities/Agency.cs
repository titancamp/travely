using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class Agency
    {
        private HashSet<Employee> _employees;
        public int Id { get; set; }
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public string Address { get; set; }
        public string LogoFile { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public User Owner { get; set; }
        public ICollection<Employee> Employees => _employees ??= new HashSet<Employee>();
    }
}
