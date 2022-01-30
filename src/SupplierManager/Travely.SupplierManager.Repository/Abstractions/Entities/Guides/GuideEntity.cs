using System;
using System.Collections.Generic;

namespace Travely.SupplierManager.Repository.Entities
{
    public class GuideEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid Image { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public ICollection<LanguageEntity<GuideEntity>> Languages { get; set; }
        // public int Experience { get; set; } // TODO TBD
        // public List<string> Skills { get; set; } // TODO TBD
        public GuidesEntity Guides { get; set; }
    }
}