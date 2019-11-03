using System;
using System.Reflection;
using System.Runtime.Loader;
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
    public class AutofacIoc : Autofac.Module
    {
        //重写父类注册方法
        protected override void Load(ContainerBuilder builder)
        {
            try
            {
                //注册数据库上下文服务
                builder.Register(options => new DbContextOptionsBuilder<ExamDbContext>()
                    .UseSqlServer(ConfigurationUtils.Configuration.GetConnectionString("ExamDbConn")).Options)
                    .InstancePerLifetimeScope();
                builder.RegisterType<ExamDbContext>().As<IExamDbContext>().InstancePerLifetimeScope();
                //注册仓储服务
                builder.RegisterGeneric(typeof(EfCoreRepository<>)).As(typeof(IEfCoreRepository<>)).InstancePerLifetimeScope();
                //注册领域层服务
                builder.RegisterAssemblyTypes(Common.GetAssembly("Domain"))
                    .Where(tp => tp.Name.EndsWith("Manage") && !tp.IsInterface && !tp.IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
                //注册应用层服务
                builder.RegisterAssemblyTypes(Common.GetAssembly("Application"))
                    .Where(tp => tp.Name.EndsWith("Service") && !tp.IsInterface && !tp.IsAbstract)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                #region 注册应用层服务
                //builder.RegisterGeneric(typeof(ClassService<,>)).As(typeof(IClassService<,>)).InstancePerLifetimeScope();
                //builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
                //builder.RegisterType<ExamService>().As<IExamService>().InstancePerLifetimeScope();
                //builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerLifetimeScope();
                //builder.RegisterType<AnswerService>().As<IAnswerService>().InstancePerLifetimeScope();
                #endregion
                #region 注册领域层服务
                //builder.RegisterGeneric(typeof(ClassManage<>)).As(typeof(IClassManage<>)).InstancePerLifetimeScope();
                //builder.RegisterType<UserManage>().As<IUserManage>().InstancePerLifetimeScope();
                //builder.RegisterType<ExamManage>().As<IExamManage>().InstancePerLifetimeScope();
                //builder.RegisterType<QuestionManage>().As<IQuestionManage>().InstancePerLifetimeScope();
                //builder.RegisterType<AnswerManage>().As<IAnswerManage>().InstancePerLifetimeScope();
                #endregion
            }
            catch (DependencyResolutionException ex)
            {
                throw ex;
            }
            base.Load(builder);
        }

        /// <summary>
        /// 服务注入
        /// </summary>
        /// <param name="services">IServiceCollection接口对象</param>
        /// <returns></returns>
        public static IServiceProvider ServiceInjection(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new AutofacIoc());
            builder.Populate(services);
            return new AutofacServiceProvider(builder.Build());
        }
    }
}
