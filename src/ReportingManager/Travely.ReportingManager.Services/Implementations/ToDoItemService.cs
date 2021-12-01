using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Travely.ReportingManager.Data.Models;
using Travely.ReportingManager.Services.Abstractions;

namespace Travely.ReportingManager.Services.Implementations
{
    public class ToDoItemService : IToDoItemService
    {
        public Task<ToDoItemEntity> GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ToDoItemEntity>> GetWhere(Expression<Func<ToDoItemEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
