using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务试题接口
    /// </summary>
    public interface IQuestionManage
    {
        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(QuestionInfo entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        bool Remove(ISpecification<QuestionInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        QuestionInfo Single(ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<QuestionInfo> Lists(ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);
    }
}
