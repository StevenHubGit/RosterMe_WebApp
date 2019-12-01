using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RosterMe.Data;
using System;
//Newtonsoft Dependencies
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;

namespace RosterMe
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
            //
            services.AddControllersWithViews();

            //Add SMTP service
            services.AddScoped<SmtpClient>((serviceProvider) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                return new SmtpClient()
                {
                    Host = config.GetValue<String>("Email:Smtp:Host"),
                    Port = config.GetValue<int>("Email:Smtp:Port"),
                    Credentials = new NetworkCredential
                    (
                        config.GetValue<String>("Email:Smtp:Username"),
                        config.GetValue<String>("Email:Smtp:Password")
                    )
                };
            });

            //Distribute Memory Cache Service
            services.AddDistributedMemoryCache();

            //Add DB Context in services
            services.AddDbContext<RosterMeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RosterMeDB")));

            //Authentication Services
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                // Make the session cookie essential
                options.Cookie.IsEssential = true;
            });

            //MVC Services
            services.AddMvc()
                .AddNewtonsoftJson();

            //Controller Services
            services.AddControllers()
                .AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. 
                //You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            //Add user session configuration
            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            //Routing format
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "default",
                    //Call Index Action in Home Controller
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                //Map route for Login
                endpoints.MapControllerRoute
                (
                    name: "DashboardPage",
                    pattern: "Dasboard/{controller=Dashboard}/{action=EmployeeList}/{id?}"
                );
            });
        }
    }
}