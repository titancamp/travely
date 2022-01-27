using System;
using Travely.ReportingManager.Data.Enums;

namespace Travely.ReportingManager.Services.Models.Responses
{
    public class ToDoItemResponse
    {
        public int Id { get; set; }
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
