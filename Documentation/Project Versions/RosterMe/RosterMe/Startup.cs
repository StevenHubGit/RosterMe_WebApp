using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using RosterMe.Data;
using System;

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
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            //
            //services.AddSingleton<IConfiguration>(Configuration);

            //Distribute Memory Cache Service
            services.AddDistributedMemoryCache();

            //Add DB Context in services
            services.AddDbContext<RosterMeContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RosterMeDB")));

            //Authentification Service (if needed)
            services.AddSession(options => 
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
            });

            //MVC Service
            services.AddMvc();
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