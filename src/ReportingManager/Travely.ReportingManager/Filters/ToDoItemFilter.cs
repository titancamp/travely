using Travely.ReportingManager.Data.Models;
using Travely.ReportingManager.Helpers;

namespace Travely.ReportingManager.Filters
{
    public class ToDoItemFilter : Filter<ToDoItemEntity>
    {
        public ToDoItemFilter()
        {
            CreateMap(nameof(ToDoItemEntity.UserId), p => p.UserId);
        }
    }
}
