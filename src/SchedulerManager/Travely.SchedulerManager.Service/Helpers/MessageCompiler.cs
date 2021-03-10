using System.Threading.Tasks;
using RazorLight;

namespace Travely.SchedulerManager.Service.Helpers
{
    internal class MessageCompiler: IMessageCompiler
    {
        public async Task<string> Compile(string text, dynamic model)
        {
            var razorEngine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(MessageCompiler))
                .UseMemoryCachingProvider()
                .Build();
            
            string result = await razorEngine.CompileRenderStringAsync(model.GetHashCode(), text, model);

            return result;
        }
    }
}
