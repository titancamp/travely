using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.IdentityManager.Repository.Abstractions.Entities
{
    public class UserEmailValidationModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
