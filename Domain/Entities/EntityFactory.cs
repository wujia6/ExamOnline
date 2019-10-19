using System;

namespace Domain.Entities
{
    /// <summary>
    /// 实体创建工厂类
    /// </summary>
    public static class EntityFactory
    {
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="parms">可变参数</param>
        /// <returns></returns>
        public static T Create<T>(params object[] parms)
        {
            Type tp = typeof(T);
            var obj = Activator.CreateInstance(typeof(T));
            if (parms.Length == 0) return (T)obj;
            int index = 0;
            foreach (var prop in tp.GetProperties())
            {
                //index = Array.FindIndex(props, p => p.Name == prop.Name);
                //判断属性类型
                if (!prop.PropertyType.IsGenericType && prop.PropertyType.IsValueType || prop.PropertyType.Equals(typeof(string)))
                {
                    prop.SetValue(obj, parms[index]);
                    index++;
                }
            }
            return (T)obj;
        }
    }
}
