using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Domain.IComm;
using Domain.Profile;
using Infrastructure.Repository;

namespace Infrastructure.Utils
{
    public class AutofacIoc
    {
        public static IContainer Injection(IServiceCollection services)
        {
            try
            {
                var builder = new ContainerBuilder();
                builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                    .UseSqlServer(ConfigurationUtils.Configuration.GetConnectionString("ExamDbConn")).Options)
                    .InstancePerLifetimeScope();
                builder.RegisterType<ExamDbContext>()
                    //.As<IExamDbContext>()
                    .AsSelf()
                    .InstancePerLifetimeScope();
                builder.RegisterGeneric(typeof(EfCoreRepository<>))
                    .As(typeof(IEfCoreRepository<>))
                    .InstancePerLifetimeScope();
                builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .Where(t => t.GetInterfaces().Any(c => c.Name.EndsWith("Manage") || c.Name.EndsWith("Service")))
                    .InstancePerLifetimeScope()
                    .AsImplementedInterfaces();
                //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                //    .Where(t => (t.Name.EndsWith("Manage") || t.Name.EndsWith("Service")) && !t.IsAbstract)
                //    .InstancePerLifetimeScope()
                //    .AsImplementedInterfaces();
                builder.Populate(services);
                return builder.Build();
            }
            catch (DependencyResolutionException ex)
            {
                throw ex;
            }
        }
    }
}
