using BLL_BusinessLogicLayer_;
using DAL_DataAccessLayer_;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI_UserInterface_
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region DAL Services
            services.AddTransient<ICategoryDb, CategoryDb>();
            services.AddTransient<IProductDb, ProductDb>();
            #endregion
            #region BLL Services
            services.AddTransient<ICategoryBs, CategoryBs>();
            services.AddTransient<IProductBs, ProductBs>(); 
            #endregion

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(@"Server=DESKTOP-8E0GKPI\SQLEXPRESS;Database=MultiTierArchitecture;Trusted_Connection=True;"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "defualt",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });
        }
    }
}
