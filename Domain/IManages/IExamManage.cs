﻿using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务考试接口
    /// </summary>
    public interface IExamManage
    {
        /// <summary>
        /// 添加或修改
        /// </summary>
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(ExamInfo inf);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        bool Remove(ISpecification<ExamInfo> spec);

        /// <summary>
        /// 单个查找
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        ExamInfo FindBySpec(ISpecification<ExamInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<ExamInfo> QueryBySpec(ISpecification<ExamInfo> spec);
    }
}
