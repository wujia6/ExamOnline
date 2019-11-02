using System.Linq;
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
        /// 单个查找
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        ExaminationInfo FindBy(ISpecification<ExaminationInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<ExaminationInfo> QuerySet(ISpecification<ExaminationInfo> spec);
    }
}
