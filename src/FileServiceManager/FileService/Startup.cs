using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using FileService.Helpers;
using FileService.DAL.Storages.Options;

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

            services.Configure<StorageOption>(Configuration.GetSection(StorageOption.Storage));


            switch (Configuration["storage:type"])
            {
                case "FileSystem":
                    services.AddFileSystemServices();
                    break;
                case "AzureBlob":
                    //TODO
                    //services.AddAzureBlogServices();
                    break;
                default:
                    services.AddFileSystemServices();
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
    }
}
