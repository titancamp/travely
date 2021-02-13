
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Travely.Shared.IdentityClient.Authorization
{
    public static class ConfigIdentityService
    {
        //
        // Summary:
        //     Adds the Microsoft.AspNetCore.Authentication.AuthenticationMiddleware to the
        //     specified Microsoft.AspNetCore.Builder.IApplicationBuilder, which enables authentication
        //     capabilities.
        //
        //     Adds the Microsoft.AspNetCore.Authorization.AuthorizationMiddleware to the specified
        //     Microsoft.AspNetCore.Builder.IApplicationBuilder, which enables authorization
        //     capabilities.
        //
        //     When authorizing a resource that is routed using endpoint routing, this call
        //     must appear between the calls to app.UseRouting() and app.UseEndpoints(...) for
        //     the middleware to function correctly.
        //
        // Parameters:
        //   app:
        //     The Microsoft.AspNetCore.Builder.IApplicationBuilder to add the middleware to.
        //
        // Returns:
        //     A reference to the IApplicationBuilder instance after the operation has completed.
        public static IApplicationBuilder ConfigureAuthentication(this IApplicationBuilder app)
        {
            app
                .UseAuthentication()
                .UseAuthorization();

            return app;
        }
    };
}
