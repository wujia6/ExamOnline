using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace Infrastructure.Utilities
{
    public class ConfigurationHelper
    {
        public ConfigurationHelper()
        {
            BaseConfig = new ConfigurationBuilder()
                .AddInMemoryCollection()
                .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public IConfiguration BaseConfig { get; set; }

        public T ApplicationSettings<T>(string key) where T: class, new()
        {
            var appSettings = new ServiceCollection().AddOptions()
                //.Configure<T>(BaseConfig.GetSection(key))
                .BuildServiceProvider()
                .GetService<IOptions<T>>()
                .Value;
            return appSettings;
        }
    }
}
