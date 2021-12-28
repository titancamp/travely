using FileService.DAL.Storages.Options;
using FileService.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Travely.Common.Swagger;

namespace FileServiceManager.FileService
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
            services.AddCors();
            services.AddControllers();
            services.AddSwagger("Travely.FileService API");

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
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors(conf => conf.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(_ => true));

            app.UseDefaultFiles();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                // UseSwaggerUI needs only when running microservice without gateway
                //app.UseSwaggerUI("Travely.FileService API");
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
