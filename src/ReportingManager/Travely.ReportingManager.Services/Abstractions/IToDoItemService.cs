using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Travely.ReportingManager.Data.Models;

namespace Travely.ReportingManager.Services.Abstractions
{
    public interface IToDoItemService
    {
        Task<ToDoItemEntity> GetById(int id);
        Task<IEnumerable<ToDoItemEntity>> GetWhere(Expression<Func<ToDoItemEntity, bool>> expression);
    }
}
