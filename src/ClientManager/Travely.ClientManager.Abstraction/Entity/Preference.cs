using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.ClientManager.Abstraction.Entity
{
    [Table("Preference")]
    public class Preference : BaseEntity
    {
        public string Note { get; set; }

        public virtual ICollection<Tourist> Tourists { get; set; }
    }
}
