using System.Text.Json.Serialization;
using Travely.Common.Entities;

namespace Travely.IdentityManager.Service.Abstractions.Models.Request
{
    public class UpdateUserRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; }
        public Permission Permission { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UserRequestModel : UpdateUserRequestModel
    {
        public string Password { get; set; }
    }
}
 