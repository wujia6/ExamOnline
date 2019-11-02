using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Infrastructure.Utils;
using Domain.IComm;
using Infrastructure.Repository;
using Domain.Profile;
using System.Reflection;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Application.IServices;
using Application.Services;

namespace ExamUI
{
    public class Startup
    {
        public Startup()
        {
            //AutoMapperHelper.SetMappings();    //加载DTO转换配置
            //数据初始化
            //using (var scope = ApplicationContainer.BeginLifetimeScope())
            //{
            //    var context = scope.Resolve<IExamDbContext>();
            //    SeedData.Initialize(context);
            //}
        }

        public IConfiguration Configuration => ConfigurationUtils.Configuration;

        public IContainer ApplicationContainer { get; private set; }
        
        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //添加授权支持，并添加使用Cookie的方式，配置登录页面和没有权限时的跳转页面
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                CookieAuthenticationDefaults.AuthenticationScheme,
                opts =>
                {
                    opts.LoginPath = new PathString("/Account/Login");//登录路径：这是当用户试图访问资源但未经过身份验证时，程序将会将请求重定向到这个相对路径。
                    opts.LogoutPath = new PathString("/Account/Login");
                    opts.AccessDeniedPath = new PathString("/Shared/Error");//禁止访问路径：当用户试图访问资源时，但未通过该资源的任何授权策略，请求将被重定向到这个相对路径。
                    opts.SlidingExpiration = true;
                });
            services.AddMvc().AddControllersAsServices();
            //注册Autofac
            var builder = new ContainerBuilder();
            builder.Populate(services);
            #region 注册应用层服务
            builder.RegisterGeneric(typeof(ClassService<,>)).As(typeof(IClassService<,>)).InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
            builder.RegisterType<AnswerService>().As<IAnswerService>().InstancePerLifetimeScope();
            #endregion
            builder.RegisterModule(new AutofacModule());
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
            app.UseStaticFiles();
            //app.UseSession();
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
