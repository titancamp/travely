
using Microsoft.IdentityModel.Tokens;

using Microsoft.Extensions.DependencyInjection;

namespace Travely.Shared.IdentityClient.Authorization
{
    public static class ConfigServicesIdentityService
    {
        //
        // Summary:
        //     Registers services required by authentication services with JWTBearer. 
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Returns:
        //     A Microsoft.Extensions.DependencyInjection.IServiceCollection that can be used
        //     to further configure Service.
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services)
        {
            services
                //.AddAuthorization(options =>
                //{
                //    options.AddPolicy("AdminRole", policy => policy.RequireRole("Admin"));
                //})
                .AddAuthentication(ApplicationInfo.Bearer)
                .AddJwtBearer(ApplicationInfo.Bearer, options =>
                {
                    options.Authority = ApplicationInfo.IdentityServerUrl; //IdentityServerApiUrl

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

            return services;
        }

        //
        // Summary:
        //     Registers services required by authentication services with OpenID Connect.
        //
        // Parameters:
        //   services:
        //     The Microsoft.Extensions.DependencyInjection.IServiceCollection.
        //
        // Returns:
        //     A Microsoft.Extensions.DependencyInjection.IServiceCollection that can be used
        //     to further configure Service.
        public static IServiceCollection ConfigureAuthenticationForOIDC(this IServiceCollection services)
        {
            services
                .AddAuthentication(options =>
                {
                    options.DefaultScheme = ApplicationInfo.Cookies;
                    options.DefaultChallengeScheme = ApplicationInfo.Oidc;
                })
                .AddCookie(ApplicationInfo.Cookies)
                .AddOpenIdConnect(ApplicationInfo.Oidc, options =>
                {
                    options.Authority = ApplicationInfo.IdentityServerUrl;

                    options.ClientId = "mvc";
                    options.ClientSecret = "secret";
                    options.ResponseType = "code";

                    options.Scope.Add("api1"); // application scopes
                    options.GetClaimsFromUserInfoEndpoint = true;

                    options.SaveTokens = true;
                });

            return services;
        }
    };
}
