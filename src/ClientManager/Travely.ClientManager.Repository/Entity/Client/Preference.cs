using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Travely.ClientManager.Repository.Entity.Client
{
    [Table("Preference")]
    public class Preference : BaseEntity
    {
        public string Note { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
