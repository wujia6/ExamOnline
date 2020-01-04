using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Application.DTO.Models;
using Domain.Entities.QuestionAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    /// <summary>
    /// 试题应用服务接口
    /// </summary>
    public interface IQuestionService
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(QuestionDto model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(Expression<Func<QuestionInfo, bool>> express);

        /// <summary>
        /// 获取单个模型
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        QuestionDto Single(Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);

        /// <summary>
        /// 获取模型集合
        /// </summary>
        /// <param name="express">表达式</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        List<QuestionDto> Lists(Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);
    }
}
