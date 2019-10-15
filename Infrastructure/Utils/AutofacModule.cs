using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Domain.Profile;
using Domain.IComm;
using Infrastructure.Repository;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utils
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //获取链接字符串配置信息
            //string connectionString = ConfigurationUtils.GetSection("SQLLocalDB");
            //注册服务
            builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                .UseSqlServer(ConfigurationUtils.Configuration.GetConnectionString("SQLLocalDB")).Options)
                .InstancePerLifetimeScope();

            builder.RegisterType<ExamDbContext>()
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
