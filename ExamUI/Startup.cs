using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Infrastructure.Utils;
using ExamUI.Filters;
using Domain.IComm;
using Domain.Profile;

namespace ExamUI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            string path = env.ContentRootPath;
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();

            //加载DTO转换配置
            AutoMapperHelper.SetMappings();
        }
        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; private set; }
        
        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加Cookie验证授权支持
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,opts =>
                {
                    opts.LoginPath = new PathString("/Account/Login");  //用户未登录重定向路径
                    opts.LogoutPath = new PathString("/Account/Login"); //退出登录重定向路径
                    opts.AccessDeniedPath = new PathString("/Shared/Error");    //未授权访问重定向路径
                    opts.SlidingExpiration = true;
                });
            services.AddAutofac();
            services.AddSession();
            //添加mvc服务与模型验证过滤器
            services.AddMvc(options=>options.Filters.Add<ModelVerifyActionFilter>()).AddControllersAsServices();
            return AutofacIoc.ServiceInjection(services);
        }

        //请求管道配置
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();    //身份验证中间件
            app.UseMvcWithDefaultRoute();
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});
        }  
    }
}
