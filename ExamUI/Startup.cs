using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using ExamUI.Filters;
using Infrastructure.Utils;
using Infrastructure.EfCore;
using Newtonsoft.Json;
using Application.ViewModels.Profiles;

namespace ExamUI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            //设置配置工具类系统路径
            ConfigurationUtils.HostEnv = env;
        }

        public IContainer ApplicationContainer { get; private set; }

        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ExamDbContext>(options => 
                options.UseSqlServer(ConfigurationUtils.Settings.GetConfig("ConnectionStrings:ExamDbConnection")));
            //添加Cookie验证授权支持
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opts =>
                {
                    opts.LoginPath = new PathString("/Account/Login");  //用户未登录重定向路径
                    opts.LogoutPath = new PathString("/Account/Login"); //退出登录重定向路径
                    opts.AccessDeniedPath = new PathString("/Shared/Error");    //未授权访问重定向路径
                    opts.SlidingExpiration = true;
                });
            //添加session服务
            services.AddSession();
            //添加mvc服务与模型验证过滤器
            services.AddMvc(options => options.Filters.Add<ModelVerifyActionFilter>())
                .AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore) //延迟加载避免循环引用
                .AddControllersAsServices();
            //初始化映射配置(注入automapper服务之前)
            Mapper.Initialize(cfg => cfg.AddProfile<MappingConfig>());
            //注入automapper服务(mvc之后)
            services.AddAutoMapper();
            //创建autofac服务容器
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacModuel());
            builder.Populate(services);
            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        //请求中间件管道配置
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseStaticFiles();
            app.UseSession();   //启用session中间件
            app.UseAuthentication();    //身份验证中间件
            app.UseMvcWithDefaultRoute();   //启用mvc默认路由中间件
        }  
    }
}
