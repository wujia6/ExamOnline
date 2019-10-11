using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.Utils
{
    /// <summary>
    /// 配置文件工具类
    /// </summary>
    public static class ConfigurationUtils
    {
        static ConfigurationUtils()
        {
            Config = new ConfigurationBuilder()
                //.AddInMemoryCollection()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        public static IConfiguration Config { get; private set; }

        public static T GetSection<T>(string key) where T : class, new()
        {
            return new ServiceCollection()
                .AddOptions()
                .Configure<T>(configureOptions => Config.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
        }

        public static string GetSection(string key)
        {
            return Config.GetValue<string>(key);
        }
    }
}
