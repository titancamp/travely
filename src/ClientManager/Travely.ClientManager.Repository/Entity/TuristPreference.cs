using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Travely.ClientManager.Repository.Entity
{
    [Table("Preference")]
    public class Preference : BaseEntity
    {
        public string Note { get; set; }

        public virtual ICollection<Turist> Turists { get; set; }
    }
}
