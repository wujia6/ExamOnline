using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Application.DTO;
using Domain.Profile;
using Domain.IComm;
using Infrastructure.Repository;

namespace ExamUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            RuleConfig.Initialize();    //加载DTO转换配置
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        //DI注册容器组件服务
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // 这个λ决定用户是否同意不必要的饼干是必要的对于一个给定的请求。
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            //services.AddAutoMapper();

            //注册Autofac
            ContainerBuilder builder = new ContainerBuilder();
            builder.Register(options => 
                new DbContextOptionsBuilder<SqlContext>()
                .UseSqlServer(Configuration.GetConnectionString("DbConnection"))
                .Options).InstancePerLifetimeScope();
            //注册服务
            builder.RegisterType<SqlContext>().As<ISqlContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IEfCoreRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.Name.EndsWith("Manage")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t=>t.Name.EndsWith("Service")).AsImplementedInterfaces();
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

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
