using Microsoft.EntityFrameworkCore;
using Autofac;
using Domain.Profile;
using Domain.IComm;
using Infrastructure.Repository;
using System.Reflection;

namespace Infrastructure.Utilities
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(options =>
                new DbContextOptionsBuilder<SqlContext>()
                .UseSqlServer(Configuration.GetConnectionString("DbConnection"))
                .Options).InstancePerLifetimeScope();
            //注册服务
            builder.RegisterType<SqlContext>().As<ISqlContext>().InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IEfCoreRepository<>)).InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Manage")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces();
            base.Load(builder);
        }
    }
}
