using ECommerceCoreMVC.Data.Entities;
using ECommerceCoreMVC.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceCoreMVC.Web
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
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"),
                    config=>
                    {
                        config.MigrationsAssembly("ECommerceCoreMVC.MigrationsSqlServer");
                    })
                .UseLazyLoadingProxies();
            });
            services.AddIdentity<User, Role>(options =>
            {
                options.Password.RequiredLength = Configuration.GetValue<int>("Application:Security:Password:RequiredLength");
                options.Password.RequireDigit = Configuration.GetValue<bool>("Application:Security:Password:RequireDigit");
                options.Password.RequireLowercase = Configuration.GetValue<bool>("Application:Security:Password:RequireLowercase");
                options.Password.RequireNonAlphanumeric = Configuration.GetValue<bool>("Application:Security:Password:RequireNonAlphanumeric");
                options.Password.RequireUppercase = Configuration.GetValue<bool>("Application:Security:Password:RequireUppercase");
                options.Password.RequiredUniqueChars = Configuration.GetValue<int>("Application:Security:Password:RequiredUniqueChars");

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                options.Lockout.MaxFailedAccessAttempts = 3;
            })
                .AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IShoppingCartService, ShoppingCartService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,AppDbContext context,RoleManager<Role> roleManager,UserManager<User> userManager)
        {
            context.Database.Migrate();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseStatusCodePagesWithReExecute("/home/error/{0}"); 

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture(CultureInfo.CreateSpecificCulture("tr-TR"));
            });

            app.UseEndpoints(endpoints =>
            {
            endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            endpoints.MapControllerRoute(
                name: "category",
                pattern: "c/{id}/{name}.html",
                defaults: new { controller = "Home", action = "Category" });

            endpoints.MapControllerRoute(
                name: "product",
                pattern: "p/{id}/{name}.html",
                defaults: new { controller = "Home", action = "Product" });

            endpoints.MapControllerRoute(
                name: "brand",
                pattern: "b/{id}/{name}.html",
                defaults: new { controller = "Home", action = "Brand" });

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            var roles = new[]
            {
                new Role { Name="Administrators", DisplayName="Yöneticiler" },
                new Role { Name="ProductAdministrators", DisplayName="Ürün Yöneticileri" },
                new Role { Name="OrderAdministrators", DisplayName="Sipariþ Yöneticileri" },
                new Role { Name="Members", DisplayName="Üyeler" },
            }.ToList();

            roles.ForEach(p =>
           {
               if (!roleManager.RoleExistsAsync(p.Name).Result)
               {
                    roleManager.CreateAsync(p).Wait();
               }
           });

            var user = new User
            {
                Name = Configuration.GetValue<string>("Application:Security:DefaultAdmin:Name"),
                UserName = Configuration.GetValue<string>("Application:Security:DefaultAdmin:UserName")
            };

            if (userManager.FindByNameAsync(user.UserName).Result==null)
            {
                userManager.CreateAsync(user, Configuration.GetValue<string>("Application:Security:DefaultAdmin:Password")).Wait();
                userManager.AddToRoleAsync(user, roles.First().Name).Wait();
            }
        }
    }
}
