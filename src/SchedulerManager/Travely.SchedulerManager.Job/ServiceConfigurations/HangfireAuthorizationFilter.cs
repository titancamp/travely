using Hangfire.Annotations;
using Hangfire.Dashboard;

namespace Travely.SchedulerManager.Job
{
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize([NotNull] DashboardContext context)
        {
            var httpContext = context.GetHttpContext();
            return httpContext.User.Identity.IsAuthenticated && httpContext.User.IsInRole("Admin"); 
        }
    }
}
