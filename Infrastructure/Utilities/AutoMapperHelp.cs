using System.Collections;
using System.Collections.Generic;
using AutoMapper;

namespace Infrastructure.Utilities
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public static class AutoMapperHelp
    {
        /// <summary>
        ///  类型映射
        /// </summary>
        public static TDest MapTo<TDest>(this object source)
        {
            if (source == null) return default(TDest);
            Mapper.Initialize(c => c.CreateMap(source.GetType(), typeof(TDest)));
            return Mapper.Map<TDest>(source);
        }

        /// <summary>
        /// 类型映射
        /// </summary>
        public static TDest MapTo<TSource, TDest>(this TSource source, TDest dest)
        {
            if (source == null)
                return dest;

            Mapper.Initialize(c => c.CreateMap<TSource, TDest>());
            return Mapper.Map(source, dest);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDest> MapToList<TDest>(this IEnumerable source)
        {
            foreach (var first in source)
            {
                var type = first.GetType();
                Mapper.Initialize(c => c.CreateMap(type, typeof(TDest)));
                break;
            }
            return Mapper.Map<List<TDest>>(source);
        }

        /// <summary>
        /// 集合列表类型映射
        /// </summary>
        public static List<TDest> MapToList<TSource, TDest>(this IEnumerable<TSource> source)
        {
            //IEnumerable<T> 类型需要创建元素的映射
            Mapper.Initialize(c => c.CreateMap<TSource, TDest>());
            return Mapper.Map<List<TDest>>(source);
        }
    }
}
