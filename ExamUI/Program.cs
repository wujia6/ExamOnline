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

namespace ExamUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //这里的ConfigureServices调用允许在启动时使用强类型的ContainerBuilder来支持ConfigureContainer。
            //如果您在这里没有调用AddAutofac，您将无法获得ConfigureContainer支持。
            //这还会自动调用Populate来将您在ConfigureServices期间注册的服务放入Autofac。
            var host = WebHost.CreateDefaultBuilder(args)
                //.ConfigureServices(services => services.AddAutofac())
                .UseStartup<Startup>()
                .Build();
            host.Run();
        }
    }
}
