# Travely
# identity-manger client config

# add below code to appsettings.json and update Audience per your application

  "TravelyIdentityConfig": {
    "Authority": "https://localhost:5001",
    "Audience": "resourceOwner",
  }

# add AddTravelyAuthentication to ConfigureServices method

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTravelyAuthentication(Configuration, WebHostEnvironment);

        ...
    }

# add ConfigureTravelyAuthentication to Configure method between UseRouting and UseEndpoints
# so it will not intercept with other middleware

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ...
        app.UseRouting();

        app.ConfigureTravelyAuthentication();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

# usage
# check UserRoles class for avalable Role types

    [Authorize(Roles = UserRoles.User)]
    {Class|Method}