using System.Linq;
using Domain.Entities.ExamAgg;
using Domain.IComm;

namespace Application.IServices
{
    /// <summary>
    /// 考试应用服务接口
    /// </summary>
    public interface IExamService
    {
        /// <summary>
        /// 插入或更新
        /// </summary>
        /// <param name="inf">实体对象</param>
        /// <returns></returns>
        bool InsertOrUpdate(ExamInfo inf);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<ExamInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        ExamInfo Single(ISpecification<ExamInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        IQueryable<ExamInfo> Query(ISpecification<ExamInfo> spec);
    }
}
