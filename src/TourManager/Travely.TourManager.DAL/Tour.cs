using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.TourManager.DAL
{
    [Table("Tour")]
    public class Tour
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [Column("TourName")]
        public string TourName { get; set; }

        [Required]
        [Column("TourTypeId")]
        public int TourTypeId { get; set; }
        public virtual TourType TourType { get; set; }

        [Column("TourStatusId")]
        public int TourStatusId { get; set; }
        public virtual TourStatus TourStatus { get; set; }

        [Column("StartDate")]
        public DateTime? StartDate { get; set; }

        [Column("EndDate")]
        public DateTime? EndDate { get; set; }

        [Column("PartnerName")]
        public string PartnerName { get; set; }

        [Column("ArrivalDate")]
        public DateTime? ArrivalDate { get; set; }

        [Column("ArrivalTime")]
        public TimeSpan? ArrivalTime { get; set; }

        [Column("ArrivalLocation")]
        public string ArrivalLocation { get; set; }

        [Column("ArrivalFlightNumber")]
        public string ArrivalFlightNumber { get; set; }

        [Column("DepartureDate")]
        public DateTime? DepartureDate { get; set; }

        [Column("DepartureTime")]
        public TimeSpan? DepartureTime { get; set; }

        [Column("DepartureLocation")]
        public string DepartureLocation { get; set; }

        [Column("DepartureFlightNumber")]
        public string DepartureFlightNumber { get; set; }

        [Column("Notes")]
        public string Notes { get; set; }

        [Column("IsDeleted")]
        public bool IsDeleted { get; set; }

        [Column("Cost")]
        public decimal Cost { get; set; }

        [Column("CreatedBy")]
        public string CreatedBy { get; set; }

        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; }

        [Column("LastEditedBy")]
        public string LastEditedBy { get; set; }

        [Column("LastEditedAt")]
        public DateTime? LastEditedAt { get; set; }

        public virtual Group TourGroup { get; set; }

    }
}
