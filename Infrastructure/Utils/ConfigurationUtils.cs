using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Utils
{
    /// <summary>
    /// 配置文件工具类
    /// </summary>
    public class ConfigurationUtils
    {
        public static IHostingEnvironment HostEnv;
        private static readonly ConfigurationUtils utils = null;
        private IConfiguration Configuration;

        private ConfigurationUtils()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(HostEnv.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        }

        /// <summary>
        /// 获取配置工具类实例对象
        /// </summary>
        public static ConfigurationUtils Settings
        {
            get { return utils ?? new ConfigurationUtils(); }
        }

        /// <summary>
        /// 获取appsettings.json配置项
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns></returns>
        public string GetConfig(string key)
        {
            return Configuration.GetSection(key).Value;
        }
    }
}
