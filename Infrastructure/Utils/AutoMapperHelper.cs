using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection;
using AutoMapper;

namespace Infrastructure.Utils
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static T MapTo<T>(this object source)
        {
            if (source == null)
                return default(T);
            Mapper.Initialize(cfg => cfg.CreateMap(source.GetType(), typeof(T)));
            return Mapper.Map<T>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDestination MapTo<TSource, TDestination>(this TDestination source, TDestination dest)
        {
            if (source == null)
                return dest;
            Mapper.Initialize(c => c.CreateMap<TSource, TDestination>());
            return Mapper.Map(source, dest);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
        {
            foreach (var first in source)
            {
                var type = first.GetType();
                Mapper.Initialize(c => c.CreateMap(type, typeof(TDestination)));
                break;
            }
            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
        {
            //IEnumerable<T> 类型需要创建元素的映射
            Mapper.Initialize(c => c.CreateMap<TSource, TDestination>());
            return Mapper.Map<List<TDestination>>(source);
        }

        /// <summary>
        /// DataReader映射
        /// </summary>
        public static IEnumerable<T> DataReaderMapTo<T>(this IDataReader reader)
        {
            Mapper.Reset();
            Mapper.Initialize(c => c.CreateMap<IDataReader, IEnumerable>());
            return Mapper.Map<IDataReader, IEnumerable<T>>(reader);
        }
    }

    //public static class AutoMapperHelper
    //{
    //    /// <summary>
    //    /// 同步锁
    //    /// </summary>
    //    private static readonly object Sync = new object();

    //    #region Mapping(将源对象映射到目标对象或集合)
    //    /// <summary>
    //    /// 将源对象映射到目标对象
    //    /// </summary>
    //    /// <typeparam name="TSource">源类型</typeparam>
    //    /// <typeparam name="TDestination">目标类型</typeparam>
    //    /// <param name="source">源对象</param>
    //    /// <param name="destination">目标对象</param>
    //    /// <returns></returns>
    //    public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination destination)
    //    {
    //        return BuildMap<TDestination>(source, destination);
    //    }

    //    /// <summary>
    //    /// 将源对象映射到目标对象
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标类型</typeparam>
    //    /// <param name="source">源对象</param>
    //    /// <returns></returns>
    //    public static TDestination MapTo<TDestination>(this object source) where TDestination : new()
    //    {
    //        return BuildMap(source, new TDestination());
    //    }

    //    /// <summary>
    //    /// 将源集合映射到目标列表
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标元素类型，范例：Sample，不用加List</typeparam>
    //    /// <param name="source">源集合</param>
    //    /// <returns></returns>
    //    public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
    //    {
    //        return MapTo<List<TDestination>>(source);
    //    }
    //    #endregion

    //    #region Extend 扩展方法
    //    /// <summary>
    //    /// 获取或生成Map
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标类型</typeparam>
    //    /// <param name="source">源对象</param>
    //    /// <param name="destination">目标对象</param>
    //    /// <returns></returns>
    //    private static TDestination BuildMap<TDestination>(object source, TDestination destination)
    //    {
    //        if (source == null)
    //            throw new ArgumentNullException("source is null");
    //        if (destination == null)
    //            throw new ArgumentNullException("destination is null");

    //        var sourceType = GetType(source);
    //        var destinationType = GetType(destination);
    //        var map = GetMap(sourceType, destinationType);

    //        if (map != null)
    //            return Mapper.Map(source, destination);

    //        lock (Sync)
    //        {
    //            map = GetMap(sourceType, destinationType);
    //            if (map != null)
    //                return Mapper.Map(source, destination);
    //            InitMaps(sourceType, destinationType);
    //        }
    //        return Mapper.Map(source, destination);
    //    }

    //    /// <summary>
    //    /// 获取映射配置
    //    /// </summary>
    //    /// <param name="sourceType">源类型</param>
    //    /// <param name="destinationType">目标类型</param>
    //    /// <returns></returns>
    //    private static TypeMap GetMap(Type sourceType, Type destinationType)
    //    {
    //        try
    //        {
    //            return Mapper.Configuration.FindTypeMapFor(sourceType, destinationType);
    //        }
    //        catch (InvalidOperationException)
    //        {
    //            lock (Sync)
    //            {
    //                try
    //                {
    //                    return Mapper.Configuration.FindTypeMapFor(sourceType, destinationType);
    //                }
    //                catch (InvalidOperationException)
    //                {
    //                    InitMaps(sourceType, destinationType);
    //                }
    //                return Mapper.Configuration.FindTypeMapFor(sourceType, destinationType);
    //            }
    //        }
    //    }

    //    /// <summary>
    //    /// 获取类型
    //    /// </summary>
    //    /// <param name="obj">对象</param>
    //    /// <returns></returns>
    //    private static Type GetType(object obj)
    //    {
    //        var type = obj.GetType();
    //        if (obj is System.Collections.IEnumerable == false)
    //        {
    //            return type;
    //        }
    //        if (type.IsArray)
    //        {
    //            return type.GetElementType();
    //        }
    //        var genericArgumentsTypes = type.GetTypeInfo().GetGenericArguments();
    //        if (genericArgumentsTypes == null || genericArgumentsTypes.Length == 0)
    //        {
    //            throw new ArgumentException("泛型类型参数不能为空");
    //        }
    //        return genericArgumentsTypes[0];
    //    }

    //    /// <summary>
    //    /// 初始化映射配置
    //    /// </summary>
    //    /// <param name="sourceType">源类型</param>
    //    /// <param name="destinationType">目标类型</param>
    //    private static void InitMaps(Type sourceType, Type destinationType)
    //    {
    //        try
    //        {
    //            var maps = Mapper.Configuration.GetAllTypeMaps();
    //            Mapper.Initialize(cfg =>
    //            {
    //                ClearConfig();
    //                foreach (var item in maps)
    //                {
    //                    cfg.CreateMap(item.SourceType, item.DestinationType);
    //                }
    //                cfg.CreateMap(sourceType, destinationType);
    //            });
    //        }
    //        catch (InvalidOperationException)
    //        {
    //            Mapper.Initialize(cfg => cfg.CreateMap(sourceType, destinationType));
    //        }
    //    }

    //    /// <summary>
    //    /// 清空配置
    //    /// </summary>
    //    private static void ClearConfig()
    //    {
    //        var typeMapper = typeof(Mapper).GetTypeInfo();
    //        var configuration = typeMapper.GetDeclaredField("_configuration");
    //        configuration.SetValue(null, null, BindingFlags.Static, null, CultureInfo.CurrentCulture);
    //    }
    //    #endregion

    //}
}
