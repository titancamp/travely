using System;
using System.Threading.Tasks;

namespace Travely.SchedulerManager.Service
{
    public class InformationJob : IAsyncJob<InformationJobParameter>
    {
        public InformationJob()
        {
        }
        public Task ExecuteAsync(InformationJobParameter parameter)
        {
            Console.WriteLine(parameter.TourName);
            return Task.CompletedTask;
        }
    }
}
