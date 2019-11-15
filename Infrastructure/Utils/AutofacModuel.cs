using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Autofac;
using Autofac.Core;
using Domain.IComm;
using Domain.Profile;
using Infrastructure.Repository;

namespace Infrastructure.Utils
{
    public class AutofacModuel : Module
    {
        //重写父类注册方法
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                //注册数据库上下文服务
                //builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                //    .UseSqlServer(ConfigurationUtils.Settings.GetConfig("ConnectionStrings:ExamDbConnection")).Options)
                //    .InstancePerLifetimeScope();
                builder.RegisterType<ExamDbContext>().As<IExamDbContext>().InstancePerLifetimeScope();
                //注册仓储服务
                builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IEfCoreRepository<>)).InstancePerLifetimeScope();
                //注册领域层服务
                builder.RegisterAssemblyTypes(Common.Instance.GetAssembly("Domain"))
                    .Where(tp => tp.Name.EndsWith("Manage") && !tp.IsInterface && !tp.IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
                //注册应用层服务
                builder.RegisterAssemblyTypes(Common.Instance.GetAssembly("Application"))
                    .Where(tp => tp.Name.EndsWith("Service") && !tp.IsInterface && !tp.IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
            }
            catch (DependencyResolutionException ex)
            {
                throw ex;
            }
            base.Load(builder);
        }
    }
}
