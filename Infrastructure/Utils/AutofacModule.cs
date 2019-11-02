using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Domain.Profile;
using Domain.IComm;
using Domain.Manages;
using Infrastructure.Repository;
using Domain.IManages;

namespace Infrastructure.Utils
{
    public class AutofacModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                //注册数据库上下文服务
                builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                    .UseSqlServer(ConfigurationUtils.Configuration.GetConnectionString("ExamDbConn")).Options)
                    .InstancePerLifetimeScope();
                builder.RegisterType<ExamDbContext>().As<IExamDbContext>().InstancePerLifetimeScope();
                builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IEfCoreRepository<>)).InstancePerLifetimeScope();
                //注册领域层服务
                builder.RegisterGeneric(typeof(ClassManage<>)).As(typeof(IClassManage<>)).InstancePerLifetimeScope();
                builder.RegisterType<UserManage>().As<IUserManage>().InstancePerLifetimeScope();
                builder.RegisterType<ExamManage>().As<IExamManage>().InstancePerLifetimeScope();
                builder.RegisterType<QuestionManage>().As<IQuestionManage>().InstancePerLifetimeScope();
                builder.RegisterType<AnswerManage>().As<IAnswerManage>().InstancePerLifetimeScope();
                //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                //    .Where(t => (t.Name.EndsWith("Manage") || t.Name.EndsWith("Service")) && !t.IsAbstract)
                //    .InstancePerLifetimeScope()
                //    .AsImplementedInterfaces();
            }
            catch (DependencyResolutionException ex)
            {
                throw ex;
            }
            base.Load(builder);
        }
    }
}
