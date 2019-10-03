using System.Linq;
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
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(AnswerInfo inf);

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
        AnswerInfo Single(ISpecification<AnswerInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IQueryable<AnswerInfo> Query(ISpecification<AnswerInfo> spec);
    }
}
