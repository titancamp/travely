using System;

namespace Travely.ReportingManager.Grpc.Models
{
    public class ToDoItemResponeModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? TourId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime? Reminder { get; set; }
        public string Description { get; set; }
        public byte Status { get; set; }
        public byte Priority { get; set; }
        public int UserId { get; set; }

    }
}
