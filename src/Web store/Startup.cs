using Microsoft.AspNetCore.Mvc;
using Web_store.Data.Interfaces;
using Web_store.Data.Mocks;

namespace Web_store;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options => options.EnableEndpointRouting = false);
        services.AddTransient<IAllItems, MockItem>();
        services.AddTransient<IItemsCategory, MockCategory>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
