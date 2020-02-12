using System.Collections.Generic;

namespace Infrastructure.Utils
{
    public abstract class BaseResult
    {
        public bool Success { get; set; }

        public string Message { get; set; }
    }

    /// <summary>
    /// 请求结果
    /// </summary>
    public class HttpResult : BaseResult
    {
        public string PathUrl { get; set; }
    }

    /// <summary>
    /// 分页帮助类
    /// </summary>
    /// <typeparam name="TDestination"></typeparam>
    public class PageResult<TDestination> : BaseResult
    {
        /// <summary>
        /// 总分页记录数
        /// </summary>
        public int Total { get; set; }

        /// <summary>
        /// 页显示记录集合
        /// </summary>
        public List<TDestination> Rows { get; set; }
    }
}
