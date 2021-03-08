using System.ComponentModel;
using System.Security.Claims;

namespace Travely.IdentityClient.Authorization.Data
{
    public record UserInfo
    {
        public int? UserId { get; set; }
        public int? EmployeeId { get; set; }
        public int? AgencyId { get; set; }
        [DisplayName(ClaimTypes.Name)]
        public string Name { get; set; }
        [DisplayName(ClaimTypes.Email)]
        public string Email { get; set; }
        [DisplayName(ClaimTypes.Role)]
        public string Role { get; set; }
    }
}
