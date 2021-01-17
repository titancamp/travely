using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travely.Repository.Common.Entity.Client
{
    [Table("ClientPreference")]
    public class ClientPreference : BaseEntity
    {
        public int ClientId { get; set; }
        public int PreferenceId { get; set; }

        [ForeignKey("ClientId")]
        public virtual Client Client { get; set; }
        [ForeignKey("PreferenceId")]
        public virtual Preference Preference { get; set; }
    }
}
