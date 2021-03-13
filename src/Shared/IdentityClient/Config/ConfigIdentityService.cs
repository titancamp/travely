namespace Microsoft.AspNetCore.Builder
{
    public static class ConfigIdentityService
    {
        public static IApplicationBuilder ConfigureTravelyAuthentication(this IApplicationBuilder app)
        {
            app
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }
    };
}
