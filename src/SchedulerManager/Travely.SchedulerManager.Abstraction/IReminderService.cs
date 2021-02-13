using System;
using System.Collections.Generic;
using System.Text;

namespace Travely.SchedulerManager
{
    public interface IReminderService
    {
        public void Get(Int32 bookingId);
        public void GetAll();
        public bool Create();
        public bool Update();
        public bool Delete(Int32 bookingId); 
    }
}
