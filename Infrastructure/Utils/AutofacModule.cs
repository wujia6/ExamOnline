﻿using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Domain.Profile;
using Domain.IComm;
using Infrastructure.Repository;

namespace Infrastructure.Utils
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //获取链接字符串配置信息
            string connectionString = ConfigurationUtils.GetSection("ExamDbStr");
            //注册服务
            //builder.RegisterType<ExamDbContext>().As<IExamDbContext>().InstancePerLifetimeScope();
            builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                .UseSqlServer(connectionString))
                .As<IExamDbContext>()
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfCoreRepository<>))
                .As(typeof(IEfCoreRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Manage"))
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}