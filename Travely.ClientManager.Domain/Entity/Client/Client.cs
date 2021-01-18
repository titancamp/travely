using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travely.ClientManager.Domain.Enum.Client;

namespace Travely.ClientManager.Domain.Entity.Client
{
    [Table("Client")]
    public class Client : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
        public ClientType Type { get; set; } // ?? 
        public string PassportId { get; set; }
        public string PhoneNumber { get; set; }
        public GenderType Gender { get; set; }
        public int Age { get; set; }

        public virtual ICollection<ClientPreference> ClientPreferences { get; set; }
    }
}
