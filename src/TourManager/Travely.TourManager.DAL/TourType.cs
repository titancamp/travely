using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("TourType")]
    public class TourType
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("TypeName")]
        public string TypeName { get; set; }

        [ForeignKey("TourTypeId")]
        public ICollection<Tour> Tours { get; set; }
    }
}
