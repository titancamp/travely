using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("TourStatus")]
    public class TourStatus
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("StatusName")]
        public string StatusName { get; set; }

        [ForeignKey("TourStatusId")]
        public ICollection<Tour> Tours { get; set; }
    }
}
