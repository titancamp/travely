using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Microsoft.Extensions.Hosting;
using Travely.Shared.IdentityClient.Authorization.Config;

namespace Travely.Gateway
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTravelyAuthentication(Configuration, Environment);
            services.AddSwaggerForOcelot(Configuration);
            services.AddOcelot().AddConsul();

            // TODO: Add CORS

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseSwaggerForOcelotUI(opt =>
                {
                    opt.PathToSwaggerGenerator = "/swagger/docs";
                    //opt.DownstreamSwaggerEndPointBasePath = "/swagger/docs";
                });
            }

            app.UseAuthentication();

            // Rewrite rule to add / at the end of the uri
            var rewriteOptions = new RewriteOptions().AddRewrite(@"^(((.*/)|(/?))[^/.]+(?!/$))$", "$1/", skipRemainingRules: true);

            //app.UseRewriter(rewriteOptions);

            // Ocelot routes rules do not work when there is no / at the end
            // Identity endpoints do not found when there is / at the end
            // E.g. /connect/token/ endpoint is not found bu /connect/token is found
            app.UseWhen(p => !p.Request.Path.StartsWithSegments("/connect/"), config => config.UseRewriter(rewriteOptions));

            app.UseWebSockets();
            app.UseOcelot().Wait();
        }
    }
}
