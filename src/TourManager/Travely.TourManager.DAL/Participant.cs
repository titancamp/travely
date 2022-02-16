using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("Participant")]
    public class Participant
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }

        [Column("GenderId")]
        public int GenderId { get; set; }

        [Column("Age")]
        public int Age { get; set; }

        [Column("PassportNumber")]
        public string PassportNumber { get; set; }

        [Column("ContactNumber")]
        [Phone]
        public string ContactNumber { get; set; }

        [Column("ContactEmail")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Column("SpecialPreferences")]
        public string SpecialPreferences { get; set; }

        [Column("IsAllInclusive")]
        public bool IsAllInclusive { get; set; }

        public virtual Gender ParticipantGender { get; set; }
        public virtual Group GroupParticipant { get; set; }
    }
}
