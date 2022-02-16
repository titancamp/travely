using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    public class GroupLanguage
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("GroupId")]
        public int GroupId { get; set; }

        [Column("LanguageId")]
        public int LanguageId { get; set; }

        public virtual Group Group { get; set; }
        public virtual Language Language { get; set; }
    }
}
