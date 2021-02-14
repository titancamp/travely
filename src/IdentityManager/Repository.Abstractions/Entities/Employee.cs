using System;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public int AgencyId { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitleId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }

        public virtual Agency Agency { get; set; }
        public virtual User User { get; set; }
    }
}
