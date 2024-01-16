using Web_store.Data;
using Web_store.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web_store.Data.Repositories;

namespace Web_store;

public class Startup
{
    public Startup(IWebHostEnvironment webHostEnvironment)
    {
        _config = new ConfigurationBuilder().SetBasePath(webHostEnvironment.ContentRootPath).AddJsonFile("dbSettings.json").Build();
    }

    private readonly IConfigurationRoot _config;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(_config.GetConnectionString("DefaultConnection")));
        services.AddMvc(options => options.EnableEndpointRouting = false);
        services.AddTransient<IAllItems, ItemRepository>();
        services.AddTransient<IItemsCategory, CategoryRepositiory>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseMvcWithDefaultRoute();

        using (var scope = app.ApplicationServices.CreateScope())
        {
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DBObjects.Initialize(applicationDbContext);
        }
    }
}
