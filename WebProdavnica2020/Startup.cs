using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WebProdavnica2020.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebProdavnica2020.Models;
using WebProdavnica2020.Servisi;

namespace WebProdavnica2020
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddControllersWithViews();
            //services.AddRazorPages();

            services.Configure<IdentityOptions>(opcije =>
            {
                // Podesavanje lozinke
                opcije.Password.RequireDigit = false;
                opcije.Password.RequiredLength = 3;
                opcije.Password.RequireNonAlphanumeric = false;
                opcije.Password.RequireUppercase = false;
                opcije.Password.RequireLowercase = false;
                opcije.Password.RequiredUniqueChars = 1;

                opcije.User.RequireUniqueEmail = true;

            });

            services.ConfigureApplicationCookie(opcije =>
            {
                // Cookie settings
                opcije.Cookie.HttpOnly = true;
                opcije.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                opcije.LoginPath = "/Account/Login";
                opcije.AccessDeniedPath = "/Account/AccessDenied";
                opcije.SlidingExpiration = true;
            });

            services.AddDbContext<ProdavnicadbContext>(opcije =>
                opcije.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddSession();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<KorpaServis>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //endpoints.MapRazorPages();
            });
        }
    }
}
