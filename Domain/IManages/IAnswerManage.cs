using System;
using System.Linq;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 答卷领域服务接口
    /// </summary>
    public interface IAnswerManage
    {
        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(AnswerInfo entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        bool Remove(ISpecification<AnswerInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        AnswerInfo Single(ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IQueryable<AnswerInfo> Lists(ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);
    }
}
