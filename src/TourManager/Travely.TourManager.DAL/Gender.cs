using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    public class Gender
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("Sex")]
        public string Sex { get; set; }

        [ForeignKey("GenderId")]
        public ICollection<Participant> Participants { get; set; }
    }
}
