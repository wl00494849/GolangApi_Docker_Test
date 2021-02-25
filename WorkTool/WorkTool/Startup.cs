using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkTool.Models;
using WorkTool.Interface;
using WorkTool.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using WorkTool.Models.DataModel;

namespace WorkTool
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        //設定應用程式服務
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(
                option => option.AddPolicy(
                    name:"AllowSpecificOrigins",
                    builer => builer.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                )
            );

            services.AddControllersWithViews();

            services.AddDbContext<WorkToolEntity>
            (
                options => options.UseSqlServer(Configuration["ConnectionStrings:WorkToolConnectionString"])
            );

            services.AddSingleton<ISqlClient>(new SqlClient(Configuration["ConnectionStrings:WorkToolConnectionString"]));
            services.AddSingleton<IUntityFunction, UntityFunction>();
            services.AddScoped<ICRUD<Work>, WorkServers>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //設定應用程式請求
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, WorkToolEntity dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            //dbContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowSpecificOrigins");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
