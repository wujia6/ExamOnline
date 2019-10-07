using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using AutoMapper;
using AutoMapper.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Utilities
{
    /// <summary>
    /// AutoMapper帮助类
    /// </summary>
    public static class AutoMapperHelper
    {
        //static AutoMapperHelper()
        //{
        //    Assembly.GetExecutingAssembly().GetTypes().Where(p => p.BaseType.Equals(typeof(Controller))).ToList()
        //        .ForEach(p =>
        //        {
        //            Mapper.Initialize(c => p.Assembly.MapTypes(c));
        //        });
        //}

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
}
