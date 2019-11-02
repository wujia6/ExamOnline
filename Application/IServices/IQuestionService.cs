using System.Collections.Generic;
using Application.DTO;
using Domain.Entities.QuestionAgg;
using Domain.IComm;

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
        bool AddOrEdit(QuestionDTO model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<QuestionInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        QuestionDTO FindBy(ISpecification<QuestionInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        List<QuestionDTO> QuerySet(ISpecification<QuestionInfo> spec);
    }
}
