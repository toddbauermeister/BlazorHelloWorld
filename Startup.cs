using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorApp.Data;

namespace BlazorApp
{
    // Configure App services and Middleware
    // Called when the application's host is built
    // TODO investigate the host: https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-5.0#host
    public class Startup
    {
        // The host provides services to this Startup constructor:
        // ConfigureServices then adds additional services
        // Both the host and app services are available throughout the app and in this file 
        // You can define (for example) seperate StartupDevelopment, StartupStaging, StartupProduction for tghe different environments
        // You can inject IWebHostEnvironment, IHostEnvironment and IConfiguration into the constructor when using the Generic Host(IHostBuilder)
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // OPTIONAL
        // Called by the runtime
        // Add services to the container here
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // NB Most services are not available until the Configure method is called!
        public void ConfigureServices(IServiceCollection services)
        {
            // This example is for Razor pages
            // There is also an 'MVC' version
            // TODO investigate the MVC version
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();
        }

        // Called by the runtime
        // Configure the HTTP request pipeline here
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // TODO debug and see what's in env or read about it
            if (env.IsDevelopment())
            {
                // Do DEV related things
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging()) 
            {
                // do STAGING related things
                // app.doStagingThings();
            }
            else if (env.IsProduction()) 
            {
                // do PROD related things
                // app.doProductionThings();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
