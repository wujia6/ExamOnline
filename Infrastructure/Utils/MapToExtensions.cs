﻿using System.Collections.Generic;
using System.Linq;

namespace AutoMapper.Execution
{
    #region AutoMapper 对象映射扩展 1.0
    public static class MapToExtensions
    {
        /// <summary>
        /// 映射源类型到目标类型
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="src">源类型</param>
        /// <returns></returns>
        public static TDestination MapTo<TDestination>(this object src)
        {
            if (src == null)
                return default(TDestination);
            var map = Mapper.Configuration.FindTypeMapFor(src.GetType(), typeof(TDestination));
            if (map == null)
                Mapper.Initialize(cfg => cfg.CreateMap(src.GetType(), typeof(TDestination)));
            return Mapper.Map<TDestination>(src);
        }

        /// <summary>
        /// 映射源类型到目标类型
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="src">源对象</param>
        /// <param name="dst">目标对象</param>
        /// <returns></returns>
        public static TDestination MapTo<TSource, TDestination>(this object src, TDestination dst)
        {
            if (src == null)
                return dst;
            var map = Mapper.Configuration.FindTypeMapFor<TSource, TDestination>();
            if (map == null)
                Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDestination>());
            return Mapper.Map(src,dst);
        }

        /// <summary>
        /// 映射源类型集合到目标类型集合
        /// </summary>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="src">源对象</param>
        /// <returns></returns>
        public static List<TDestination> MapToList<TDestination>(this IEnumerable<object> src)
        {
            var sourceType = src.FirstOrDefault().GetType();
            var map = Mapper.Configuration.FindTypeMapFor(sourceType, typeof(TDestination));
            if (map == null)
                Mapper.Initialize(cfg => cfg.CreateMap(src.GetType(), typeof(TDestination)));
            return Mapper.Map<List<TDestination>>(src);
        }

        /// <summary>
        /// 映射源类型集合到目标类型集合
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TDestination">目标类型</typeparam>
        /// <param name="src">源对象</param>
        /// <returns></returns>
        public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> src)
        {
            var map = Mapper.Configuration.FindTypeMapFor<TSource, TDestination>();
            if (map == null)
                Mapper.Initialize(cfg => cfg.CreateMap<TSource, TDestination>());
            return Mapper.Map<List<TDestination>>(src);
        }
    }
    #endregion

    #region AutoMapper 对象映射扩展 2.0
    //public static partial class Extensions
    //{
    //    /// <summary>
    //    /// 同步锁
    //    /// </summary>
    //    private static readonly object Sync = new object();

    //    #region MapTo(将源对象映射到目标对象)

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
    //        return MapTo<TDestination>(source, destination);
    //    }

    //    /// <summary>
    //    /// 将源对象映射到目标对象
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标类型</typeparam>
    //    /// <param name="source">源对象</param>
    //    /// <returns></returns>
    //    public static TDestination MapTo<TDestination>(this object source) where TDestination : new()
    //    {
    //        return MapTo(source, new TDestination());
    //    }

    //    /// <summary>
    //    /// 将源对象映射到目标对象
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标类型</typeparam>
    //    /// <param name="source">源对象</param>
    //    /// <param name="destination">目标对象</param>
    //    /// <returns></returns>
    //    private static TDestination MapTo<TDestination>(object source, TDestination destination)
    //    {
    //        if (source == null)
    //        {
    //            throw new ArgumentNullException(nameof(source));
    //        }
    //        if (destination == null)
    //        {
    //            throw new ArgumentNullException(nameof(destination));
    //        }
    //        var sourceType = GetType(source);
    //        var destinationType = GetType(destination);
    //        var map = GetMap(sourceType, destinationType);
    //        if (map != null)
    //        {
    //            return Mapper.Map(source, destination);
    //        }
    //        lock (Sync)
    //        {
    //            map = GetMap(sourceType, destinationType);
    //            if (map != null)
    //            {
    //                return Mapper.Map(source, destination);
    //            }
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
    //            Mapper.Initialize(config =>
    //            {
    //                ClearConfig();
    //                foreach (var item in maps)
    //                {
    //                    config.CreateMap(item.SourceType, item.DestinationType);
    //                }
    //                config.CreateMap(sourceType, destinationType);
    //            });
    //        }
    //        catch (InvalidOperationException)
    //        {
    //            Mapper.Initialize(config =>
    //            {
    //                config.CreateMap(sourceType, destinationType);
    //            });
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

    //    #region MapToList(将源集合映射到目标列表)

    //    /// <summary>
    //    /// 将源集合映射到目标列表
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标元素类型，范例：Sample，不用加List</typeparam>
    //    /// <param name="source">源集合</param>
    //    /// <returns></returns>
    //    public static List<TDestination> MapToList<TDestination>(this System.Collections.IEnumerable source)
    //    {
    //        return MapTo<List<TDestination>>(source);
    //    }

    //    #endregion
    //}
    #endregion
}
