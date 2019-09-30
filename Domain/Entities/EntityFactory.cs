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
            var obj = Activator.CreateInstance(typeof(T));
            var props = typeof(T).GetProperties();
            if (parms.Length > 0)
            {
                for (int i = 0; i < props.Length; i++)
                {
                    var property = props[i];
                    property.SetValue(obj, parms[i]);
                }
            }
            return (T)obj;
        }
    }
}
