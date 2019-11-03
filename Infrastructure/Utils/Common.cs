using System;
using System.Reflection;
using System.Runtime.Loader;

namespace Infrastructure.Utils
{
    public class Common
    {
        /// <summary>
        /// 获取指定程序集
        /// </summary>
        /// <param name="assemblyName">程序集名称</param>
        /// <returns></returns>
        public static Assembly GetAssembly(string assemblyName)
        {
            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
            return assembly;
        }
    }
}
