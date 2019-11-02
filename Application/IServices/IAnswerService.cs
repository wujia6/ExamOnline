using System.Collections.Generic;
using Application.DTO;
using Domain.Entities.AnwserAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 答题卷应用服务接口
    /// </summary>
    public interface IAnswerService
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="model">实体对象</param>
        /// <returns></returns>
        bool AddOrEdit(AnswerDTO model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<AnswerInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        AnswerDTO FindBy(ISpecification<AnswerInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        List<AnswerDTO> QuerySet(ISpecification<AnswerInfo> spec);
    }
}
