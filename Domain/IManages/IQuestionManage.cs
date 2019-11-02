using System.Linq;
using Domain.Entities.QuestionAgg;
using Domain.IComm;

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
        /// 单个查找
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        QuestionInfo FindBy(ISpecification<QuestionInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约表达式</param>
        /// <returns></returns>
        IQueryable<QuestionInfo> QuerySet(ISpecification<QuestionInfo> spec);
    }
}
