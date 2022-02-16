using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("Group")]
    public class Group
    {
        [ForeignKey("Tour")]
        [Column("Id")]
        public int Id { get; set; }

        [Range(1, 999)]
        [Column("NumberOfParticipants")]
        public int NumberOfParticipants { get; set; }

        [Range(1, 999)]
        [Column("NumberOfChildren")]
        public int NumberOfChildren { get; set; }

        [Column("Country")]
        public string Country { get; set; }

        [Column("Preferences")]
        public IList<string> Preferences { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        public virtual Tour Tour { get; set; }

        [ForeignKey("GroupId")]
        public ICollection<GroupLanguage> GroupLanguages { get; set; }

        [ForeignKey("GroupId")]
        public ICollection<Attachment> Attachments { get; set; }

        [ForeignKey("GroupId")]
        public ICollection<Participant> Participants { get; set; }
    }
}
