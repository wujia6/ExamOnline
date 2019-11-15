using Microsoft.Extensions.Configuration;

namespace ExamUI
{
    public class AppSettings
    {
        private static readonly object objLock = new object();
        private static AppSettings instance = null;

        private AppSettings()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            Config = new ConfigurationBuilder()
                .SetBasePath(path)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true) 
                .Build();
        }

        private IConfigurationRoot Config { get; }

        /// <summary>
        /// 获取配置读取类实例对象
        /// </summary>
        public static AppSettings Settings
        {
            get
            {
                lock(objLock)
                {
                    return instance ?? new AppSettings();
                }
            }
        }

        /// <summary>
        /// 获取配置项
        /// </summary>
        /// <param name="key">名称</param>
        /// <returns></returns>
        public static string GetConfig(string key)
        {
            return Settings.Config.GetSection(key).Value;
        }
    }
}
