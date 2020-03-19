using System.Linq;
using Autofac;
using Autofac.Core;
using AutoMapper;
using Domain.IComm;
using Infrastructure.EfCore;
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
                //注册AutoMapper服务
                //builder.RegisterType<Mapper>().As<IMapper>().InstancePerLifetimeScope();
                //注册仓储服务
                builder.RegisterGeneric(typeof(EfCoreRepository<>))
                    .As(typeof(IEfCoreRepository<>)).InstancePerLifetimeScope();
                //注册领域层服务
                builder.RegisterAssemblyTypes(ApplicationFactory.GetAssembly("Domain"))
                    .Where(tp => tp.Name.EndsWith("Manage") && !tp.IsInterface && !tp.IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
                //注册应用层服务
                builder.RegisterAssemblyTypes(ApplicationFactory.GetAssembly("Application"))
                    .Where(tp => tp.Name.EndsWith("Service") && !tp.IsInterface && !tp.IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
                //注册缓存工具类(单列)
                builder.RegisterType<CacheUtils>().AsSelf().SingleInstance();
            }
            catch (DependencyResolutionException ex)
            {
                throw ex;
            }
            base.Load(builder);
        }
    }
}
