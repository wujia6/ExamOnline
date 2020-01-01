using System.Collections;
using System.Collections.Generic;

namespace AutoMapper.Execution
{
    /// <summary>
    /// AutoMapper映射扩展类
    /// </summary>
    public static class MapToExtension
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
        public static List<TDestination> MapToList<TDestination>(this IEnumerable src)
        {
            var sourceType = src.GetEnumerator().Current.GetType();
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
}
