using System.Linq;
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
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(QuestionDTO inf);

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
        QuestionDTO Single(ISpecification<QuestionInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IQueryable<QuestionDTO> Query(ISpecification<QuestionInfo> spec);
    }
}
