using System;

namespace Domain.Entities
{
    public static class EntityFactory
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="parms">可变参数</param>
        /// <returns></returns>
        public static T CreateInstance<T>(params object[] parms)
        {
            T obj = (T)Activator.CreateInstance(typeof(T));
            if (parms.Length > 0)
            {
                int index = 0;
                var props = typeof(T).GetProperties();
                foreach (var prop in props)
                {
                    //index = Array.FindIndex(props, p => p.Name == prop.Name);
                    if (!prop.PropertyType.IsGenericType && prop.PropertyType.IsValueType || prop.PropertyType.Equals(typeof(string)))
                    {
                        prop.SetValue(obj, parms[index]);
                        index++;
                    }
                }
            }
            return obj;
        }
    }
}
