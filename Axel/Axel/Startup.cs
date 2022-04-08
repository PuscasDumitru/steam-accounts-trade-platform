
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Domain.Repositories;
using Services.Interfaces;
using Persistence;
using Persistence.Repositories;
using Services.Implementation;
using System.IO;

namespace Axel
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

            services.AddScoped<IServiceManager, ServiceManager>();

            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddDbContext<RepositoryDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("Axel")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = ".@abcdefghijklmnopqrstuvwxyz";
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddDefaultUI()
                .AddEntityFrameworkStores<RepositoryDbContext>(); 
              
            
            services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = Configuration["Authentication:Google:ClientId"];
                    options.ClientSecret = Configuration["Authentication:Google:ClientSecret"];

                })
                .AddFacebook(options =>
                {
                    options.AppId = Configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = Configuration["Authentication:Facebook:AppSecret"];

                });

            services.AddRazorPages();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Superuser",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "Admin",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                endpoints.MapRazorPages();
            });

            Syncfusion.Licensing.SyncfusionLicenseProvider
                .RegisterLicense("NjAwNjYwQDMxMzkyZTM0MmUzMFpYSVhaNEc5aklDWUQvdS8wRE0wMFBKSGw5VVE5ckdkUzI5QkRiUkRXdG89");

            if (Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion")))
            {
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"js", @"ej2")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"js", @"ej2"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"scripts", @"ej2.min.js"), 
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"js", @"ej2", @"ej2.min.js"));
                }

                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"bootstrap.css"), 
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"bootstrap.css"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"bootstrap4.css"),
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"bootstrap4.css"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"material.css"), 
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"material.css"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"highcontrast.css"),
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"highcontrast.css"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"fabric.css"), 
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"fabric.css"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"tailwind.css"), 
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"tailwind.css"));
                    File.Copy(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules", @"@syncfusion", @"ej2-js-es5", @"styles", @"bootstrap5.css"),
                        Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", @"css", @"ej2", @"bootstrap5.css"));
                }
            }
        }
    }
}
