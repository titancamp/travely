using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.ClientManager.Domain.Entity.Client
{
    [Table("Preference")]
    public class Preference : BaseEntity
    {
        public string Description { get; set; }

        public virtual ICollection<ClientPreference> ClientPreferences { get; set; }
    }
}
