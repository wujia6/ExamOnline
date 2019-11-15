using System;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utils
{
    /// <summary>
    /// 配置文件工具类
    /// </summary>
    public static class ConfigurationUtils
    {
        static ConfigurationUtils()
        {
            string domain = Environment.CurrentDirectory;
            Config = new ConfigurationBuilder()
                .SetBasePath(domain)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static IConfiguration Config { get; set; }

        /// <summary>
        /// 获取appsettings.json配置项
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            return Config.GetSection(key).Value;
        }
    }
}
