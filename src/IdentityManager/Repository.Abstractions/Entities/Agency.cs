using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class Agency
    {
        private HashSet<User> _users;
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? LogoFile { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public ICollection<User> Users => _users ??= new HashSet<User>();
    }
}
