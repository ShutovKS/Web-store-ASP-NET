using Web_store.Data;
using Web_store.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Web_store.Data.Repositories;
using Web_store.Data.Models;

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
        services.AddTransient<IItems, ItemsRepository>();
        services.AddTransient<IItemsCategory, CategoryRepository>();
        services.AddTransient<IOrders, OrdersReposytory>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped(sp => ShopCart.GetCart(sp));

        services.AddMemoryCache();
        services.AddSession();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseDeveloperExceptionPage();
        app.UseStatusCodePages();
        app.UseStaticFiles();
        app.UseSession();
        app.UseMvc(routes =>
        {
            routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
            routes.MapRoute(name: "categoryFilter", template: "Items/{action}/{category?}", defaults: new { Controllers = "Items", action = "List" });
        });

        using (var scope = app.ApplicationServices.CreateScope())
        {
            var applicationDbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DBObjects.Initialize(applicationDbContext);
        }
    }
}
