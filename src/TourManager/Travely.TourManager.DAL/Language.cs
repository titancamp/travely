using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("Language")]
    public class Language
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("LanguageName")]
        public string LanguageName { get; set; }

        [ForeignKey("LanguageId")]
        public ICollection<GroupLanguage> GroupLanguages { get; set; }
    }
}
