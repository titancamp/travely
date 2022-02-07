using System.Text.Json.Serialization;
using Travely.Common.Entities;

namespace Travely.IdentityManager.Service.Abstractions.Models.Request
{
    public class UserRequestModel
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string UserName { get; set; }
        public Permission Permission { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}
 