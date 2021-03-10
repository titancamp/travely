using System.Threading.Tasks;

namespace Travely.SchedulerManager
{
    public interface IMessageCompiler
    {
        Task<string> Compile(string text, dynamic model);
    }
}