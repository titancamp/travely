using System;

namespace TourManager.Service.Model.ReportingManager
{
    public class CreateToDoItemModel
    {
        public string Name { get; set; }
        public int? TourId { get; set; }
        public DateTime Deadline { get; set; }
        public string Description { get; set; }

        // public ToDoItemState TaskStatus { get; set; }
    } 
}
