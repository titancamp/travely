using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigServicesIdentityService
    {
        public static IServiceCollection IdentityApplicationBuilderExtensions(this IServiceCollection services, IHostEnvironment environment)
        {
            services
                .AddAuthorization(options =>
                {
                    options.AddPolicy("admin", policy => policy.RequireClaim("Admin"));
                })
                .AddAuthentication(options => {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.Authority = "https://localhost:5123";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuerSigningKey = true,
                        //ValidateAudience = true,
                        //ValidateIssuer = true,
                        RoleClaimType = "role",
                        NameClaimType = "sub",
                    };

                    if (!environment.IsDevelopment())
                    {
                        options.RequireHttpsMetadata = true;
                    }

                    options.SaveToken = true;
                });

            return services;
        }
    };
}
