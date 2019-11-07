using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Infrastructure.Utils;

namespace ExamUI
{
    public class Startup
    {
        public Startup()
        {
            //加载DTO转换配置
            AutoMapperHelper.SetMappings();
            //数据初始化
            //using (var scope = ApplicationContainer.BeginLifetimeScope())
            //{
            //    var context = scope.Resolve<IExamDbContext>();
            //    SeedData.Initialize(context);
            //}
        }

        public IConfiguration Configuration => ConfigurationUtils.Configuration;

        //public IContainer ApplicationContainer { get; private set; }
        
        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加授权支持，并添加使用Cookie的方式，配置登录页面和没有权限时的跳转页面
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,opts =>
                {
                    opts.LoginPath = new PathString("/Account/Login");//登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径。
                    opts.LogoutPath = new PathString("/Account/Login");
                    opts.AccessDeniedPath = new PathString("/Shared/Error");//禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径。
                    opts.SlidingExpiration = true;
                });
            services.AddSession();
            services.AddMvc().AddControllersAsServices();
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
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }  
    }
}
