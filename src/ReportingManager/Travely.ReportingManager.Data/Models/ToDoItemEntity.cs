using System;

namespace Travely.ReportingManager.Data.Models
{
    public class ToDoItemEntity:BaseEntity
    {
        public string Name { get; set; }
        public int? TourId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? Reminder { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public int Priority { get; set; }
        public long UserId { get; set; }
    }
}
