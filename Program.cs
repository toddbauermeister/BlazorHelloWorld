using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

//TODO: push to repo

// Blazor Fundamentals
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/?view=aspnetcore-5.0

// Overview - DONE
// The Startup class - got up to Multiple Startup https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-5.0#multiple-startup
// Dependency injection (services)
// Middleware
// Servers
// Configuration
// Options
// Environments (dev, stage, prod)
// Logging
// Routing
// Handle errors
// Make HTTP requests
// Static files

// This Tutorial
// https://dotnet.microsoft.com/learn/aspnet/blazor-tutorial/intro

// Create your app - DONE (dotnet new blazorserver -o BlazorApp --no-https)
// Run your app - DONE (dotnet watch run)
// Try the counter - DONE
// Add a component
// Modify a component
// Next steps

namespace BlazorApp
{
    public class Program
    {
        // Main method starts up the application
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Host Builder, called by Main
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Specifies the Startup class
                    // Which has functions:

                    // Startup() ->  Constructor
                    // ConfigureServices(IServiceCollection services) -> Optional, Add services to the container here, Called by the runtime
                    // Configure() -> Configure http request pipeline here, Called by the runtime

                    webBuilder.UseStartup<Startup>();
                });
    }
}
