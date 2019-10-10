using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Domain.Profile;
using Domain.IComm;
using Infrastructure.Repository;

namespace Infrastructure.Utilities
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //获取配置信息
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            //注册服务
            //builder.RegisterType<ExamDbContext>().As<IExamDbContext>().InstancePerLifetimeScope();
            builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                .UseSqlServer(config.GetConnectionString("ExamDbStr")))
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
