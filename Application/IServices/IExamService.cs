using System.Collections.Generic;
using Application.DTO;
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
        bool InsertOrUpdate(ExaminationDTO inf);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        bool Remove(ISpecification<ExaminationInfo> spec);

        /// <summary>
        /// 查询单个
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        ExaminationDTO Single(ISpecification<ExaminationInfo> spec);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="spec">规约对象</param>
        /// <returns></returns>
        List<ExaminationDTO> Query(ISpecification<ExaminationInfo> spec);
    }
}
