using System.Collections.Generic;
using AutoMapper.Execution;

namespace System
{
    /// <summary>
    /// 分页数据扩展
    /// </summary>
    public static class PaginatorExtensions
    {
        /// <summary>
        /// 分页数据扩展
        /// </summary>
        /// <typeparam name="TDestination">页记录（DTO）类型</typeparam>
        /// <param name="anonymoues">数据源（匿名）对象</param>
        /// <returns></returns>
        public static PageResult<TDestination> ToPageResult<TDestination>(this object anonymoues)
        {
            var pageResult = new PageResult<TDestination>
            {
                Total = Convert.ToInt32(anonymoues.GetType().GetProperty("Total").GetValue(anonymoues)),
                Rows = (anonymoues.GetType().GetProperty("Rows").GetValue(anonymoues) as IEnumerable<object>).MapToList<TDestination>()
            };
            return pageResult;
        }
    }

    /// <summary>
    /// 分页帮助类
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    public class PageResult<TDestination>
    {
        /// <summary>
        /// 总记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 页显示记录集合
        /// </summary>
        public IEnumerable<TDestination> Rows { get; set; }
    }
}
