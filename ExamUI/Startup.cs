using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infrastructure.Utils;
using Domain.IComm;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace ExamUI
{
    public class Startup
    {
        public Startup()
        {
            //AutoMapperHelper.SetMappings();    //加载DTO转换配置
        }

        public IConfiguration Configuration => ConfigurationUtils.Configuration;

        public IContainer ApplicationContainer { get; private set; }
        
        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加授权支持，并添加使用Cookie的方式，配置登录页面和没有权限时的跳转页面
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,opts=> {
                    opts.LoginPath = new PathString("/Account/Login");//登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径。
                    opts.AccessDeniedPath = new PathString("/Shared/Error");//禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径。
                    //Cookie可以分为永久性的和临时性的。 临时性的是指只在当前浏览器进程里有效，浏览器一旦关闭就失效（被浏览器删除）。
                    //永久性的是指Cookie指定了一个过期时间，在这个时间到达之前，此cookie一直有效（浏览器一直记录着此cookie的存在）。 
                    //slidingExpriation的作用是，指示浏览器把cookie作为永久性cookie存储，但是会自动更改过期时间，
                    //以使用户不会在登录后并一直活动，但是一段时间后却自动注销。也就是说，你10点登录了，
                    //服务器端设置的TimeOut为30分钟，如果slidingExpriation为false,那么10: 30以后，你就必须重新登录。
                    //如果为true的话，你10: 16分时打开了一个新页面，服务器就会通知浏览器，把过期时间修改为10: 46。
                    opts.SlidingExpiration = true;
                });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSession();
            services.AddAutoMapper();

            //注册Autofac
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule<AutofacModule>();
            builder.Populate(services);
            this.ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(this.ApplicationContainer);
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
            app.UseAuthentication();    //身份验证中间件
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseCookiePolicy();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            //数据初始化
            //using (var scope = ApplicationContainer.BeginLifetimeScope())
            //{
            //    var context = scope.Resolve<IExamDbContext>();
            //    SeedData.Initialize(context);
            //}
        }  
    }
}
