using System.Security.Claims;

namespace Travely.Shared.IdentityClient.Authorization.Common
{
    public static class UserRoles
    {
        public const string User = "User";
        public const string Admin = "Admin";
    }

    public static class TravelyClaims
    {
        public const string UserId = "sub";
        public const string AgencyId = "AgencyId";
        public const string EmployeeId = "EmployeeId";
        public const string Role = ClaimTypes.Role;
        public const string Name = ClaimTypes.Name;
        public const string Email = ClaimTypes.Email;
    }
}
