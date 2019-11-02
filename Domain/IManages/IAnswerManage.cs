using System.Linq;
using Domain.Entities.AnwserAgg;
using Domain.IComm;

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
        /// 单个查找
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        AnswerInfo FindBy(ISpecification<AnswerInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<AnswerInfo> QuerySet(ISpecification<AnswerInfo> spec);
    }
}
