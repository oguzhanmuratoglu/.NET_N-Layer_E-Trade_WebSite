using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Mrt.Northwind.Business.Abstract;
using Mrt.Northwind.Business.Concrete;
using Mrt.Northwind.DataAccess.Abstract;
using Mrt.Northwind.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Mrt.Northwind.MvcWepUI.Entities;
using Mrt.Northwind.MvcWepUI.Services;


namespace Mrt.Northwind.MvcWepUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorization();
            services.AddAuthentication();
            services.AddHttpContextAccessor();
            services.AddSession();
            services.AddDistributedMemoryCache();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICardSessionService, CardSessionService>();
            services.AddSingleton<ICardService, CardService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<CustomIdentityDbContext>(options=>
                options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Database=Northwind; Trusted_Connection=True"));
            services.AddIdentity<CustomIdentityUser, CustomIdentityRole>()
                .AddEntityFrameworkStores<CustomIdentityDbContext>().AddDefaultTokenProviders();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseSession();
            app.UseStaticFiles();
            app.UseMvc(c=>
                c.MapRoute("Default", "{controller=Product}/{action=Index}/{id?}"));

        }

    }
}
