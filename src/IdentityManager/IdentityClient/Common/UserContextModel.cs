using Travely.Common.Entities;

namespace Travely.IdentityClient.Common
{
    public class UserContextModel
    {
        public int UserId { get; set; }
        public Permission Permissions { get; set; }
        public int AgencyId { get; set; }
    }
}
