using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FileService.DAL;
using FileService.Helpers;

namespace FileServiceManager.FileService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.IgnoreObsoleteActions();
                options.DescribeAllParametersInCamelCase();
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Travely.FileService API",
                    Version = "v1",
                    TermsOfService = new System.Uri("https://github.com/titancamp/travely"),
                    Contact = new OpenApiContact { Name = "https://www.servicetitan.com" }
                });
            });

            switch (Configuration["storage:type"])
            {
                case "FileSystem":
                    RegisterFileSystemService(services);
                    break;
                case "AzureBlob":
                    //services.AddScoped<IStorage, AzureBlobStorage>();
                    break;
                default:
                    RegisterFileSystemService(services);
                    break;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();

                // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
                app.UseSwaggerUI(c =>
                {
                    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
                    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "Travely.FileService API");
                });
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void RegisterFileSystemService(IServiceCollection services)
        {
            services.AddScoped<IFileSystemConfigurator, FileSystemJsonConfigurator>();
            services.AddScoped<IStorage, FileSystemStorage>();
        }
    }
}
