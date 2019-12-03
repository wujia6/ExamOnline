using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

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
        /// <param name="entity">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(ExaminationInfo entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        bool Remove(ISpecification<ExaminationInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        ExaminationInfo Single(ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <param name="include">包含导航属性</param>
        /// <returns></returns>
        IEnumerable<ExaminationInfo> Lists(ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);
    }
}
