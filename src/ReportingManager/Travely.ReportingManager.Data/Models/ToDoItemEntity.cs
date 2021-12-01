using System;
using Travely.ReportingManager.Data.Enums;

namespace Travely.ReportingManager.Data.Models
{
    public class ToDoItemEntity:BaseEntity
    {
        public string Name { get; set; }
        public int? TourId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? Reminder { get; set; }
        public string Description { get; set; }
        public ToDoItemState Status { get; set; }
        public ToDoItemPriority Priority { get; set; }
        public int UserId { get; set; }
    }
}
