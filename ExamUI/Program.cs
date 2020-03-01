using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.IComm;
using Infrastructure.EfCore;
using Microsoft.Extensions.DependencyInjection;

namespace ExamUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            //初始种子数据
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<IExamDbContext>();
                    DbSeed.InitializeAsync(context).Wait();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            host.Run();
        }

        //使用预配置的默认值初始化 Microsoft.AspNetCore.Hosting.WebHostBuilder 类的新实例。
        //指定要由 web 主机使用的启动类型。相当于注册了一个IStartup服务。
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();
    }
}
