using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Application.DTO.Mappings
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    //public static class AutoMapperHelper
    //{
    //    /// <summary>
    //    /// 源类型映射到目标类型
    //    /// </summary>
    //    /// <typeparam name="TDestination">目标类型</typeparam>
    //    /// <param name="src">源类型</param>
    //    /// <returns></returns>
    //    public static TDestination SingleTo<TDestination>(object src)
    //    {
    //        if (src==null)
    //            return default(TDestination);
            
    //        var map = Mapper.Configuration.FindTypeMapFor(src.GetType(), typeof(TDestination));
    //        if (map == null)
    //            Mapper.Initialize(cfg => cfg.CreateMap(src.GetType(), typeof(TDestination)));
    //        return Mapper.Map<TDestination>(src);
    //    }

    //    /// <summary>
    //    ///  类型映射
    //    /// </summary>
    //    public static TDestination MapTo<TDestination>(this object source)
    //    {
    //        if (source == null)    return default(TDestination);
    //        var map = Mapper.Configuration.FindTypeMapFor(source.GetType(), typeof(TDestination));
    //        if(map == null)
    //            Mapper.Initialize(cfg => cfg.CreateMap(source.GetType(), typeof(TDestination)));
    //        return Mapper.Map<TDestination>(source);
    //    }
        
    //    /// <summary>
    //    /// 类型映射
    //    /// </summary>
    //    public static TDestination MapTo<TSource, TDestination>(this TSource source, TDestination dest)
    //    {
    //        if (source == null)    return dest;
    //        var map = Mapper.Configuration.FindTypeMapFor(source.GetType(), dest.GetType());
    //        if (map == null)
    //            Mapper.Initialize(cfg => cfg.CreateMap<TSource,TDestination>());
    //        return Mapper.Map(source, dest);
    //    }

    //    /// <summary>
    //    /// 集合列表类型映射
    //    /// </summary>
    //    public static List<TDestination> MapToList<TDestination>(this IEnumerable source)
    //    {
    //        foreach (var first in source)
    //        {
    //            var sourceType = first.GetType();
    //            var map = Mapper.Configuration.FindTypeMapFor(source.GetType(), typeof(TDestination));
    //            if (map == null)
    //                Mapper.Initialize(c => c.CreateMap(sourceType, typeof(TDestination)));
    //            break;
    //        }
    //        return Mapper.Map<List<TDestination>>(source);
    //    }

    //    /// <summary>
    //    /// 集合列表类型映射
    //    /// </summary>
    //    public static List<TDestination> MapToList<TSource, TDestination>(this IEnumerable<TSource> source)
    //    {
    //        //IEnumerable<T> 类型需要创建元素的映射
    //        var map = Mapper.Configuration.FindTypeMapFor(typeof(TSource), typeof(TDestination));
    //        if (map == null)
    //            Mapper.Initialize(c => c.CreateMap<TSource, TDestination>());
    //        return Mapper.Map<List<TDestination>>(source);
    //    }
    //}
}
