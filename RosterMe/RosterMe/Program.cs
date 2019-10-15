using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RosterMe.Data;

namespace RosterMe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Build Host
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                //Store Service Provider
                var services = scope.ServiceProvider;

                try
                {
                    //Get & store service from Context
                    var context = services.GetRequiredService<RosterMeContext>();

                    //Initialize Seed Data with servie
                    SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    //Get & store service from Program
                    var logger = services.GetRequiredService<ILogger<Program>>();

                    //Print error
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            //Run host
            host.Run();

        }

        /* ---- Build host using Startup ---- */
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
