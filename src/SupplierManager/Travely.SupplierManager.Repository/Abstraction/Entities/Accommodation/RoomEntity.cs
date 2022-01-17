using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Travely.SupplierManager.Repository.Entities
{
    public class RoomEntity
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public RoomType Type { get; set; }
        [Range(0, 99)]
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(20,2)")]
        public decimal Price { get; set; }
        [Range(0, 99)]
        public int NumberOfBeds { get; set; }
        [Range(0, 99)]
        public int AdditionalBeds { get; set; }
        public ICollection<RoomServiceEntity> Services { get; set; }
        
        public AccommodationEntity AccommodationEntity { get; set; }
    }
}