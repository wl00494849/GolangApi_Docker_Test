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
            //跨域處理
            services.AddCors(
                option => option.AddPolicy(
                    name: "AllowSpecificOjrigins",
                    builer => builer.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowCredentials()
                )
            );

            services.AddControllersWithViews();
            //新增Swagger Doc文件
            services.AddSwaggerGen();
            
            //MS-SQL Server
            // services.AddDbContext<WorkToolEntity>
            // (
            //     options => options.UseSqlServer(Configuration["ConnectionStrings:WorkToolConnectionString"])
            // );
            
            //MySQL Server
            services.AddDbContext<WorkToolEntity>
            (
                options => options.UseMySQL(Configuration["ConnectionStrings:MySQL_WorkToolConnectionString"])
            );

            //Singleton整個程序只建立一個
            services.AddSingleton<IUntityFunction, UntityFunction>();
            //Scoped網站Request到Respons共用一個
            services.AddScoped<ISqlClient, SqlClient>();
            services.AddScoped<IWork, WorkServers>();
            //Transient每請求一次建立一個新的

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

            //設定文件路由
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger");
                c.RoutePrefix = string.Empty;
            });

            //dbContext.Database.EnsureCreated();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            //跨域處理
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
