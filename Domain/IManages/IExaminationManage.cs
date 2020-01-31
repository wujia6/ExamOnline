using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.ExamAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务考试接口
    /// </summary>
    public interface IExaminationManage
    {
        bool SaveAs(ExaminationInfo entity);

        bool EditTo(ExaminationInfo entity);

        bool RemoveAt(ISpecification<ExaminationInfo> spec);

        Task<ExaminationInfo> SingleAsync(
            ISpecification<ExaminationInfo> spec,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);

        Task<IEnumerable<ExaminationInfo>> QueryAsync(
            ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);

        Task<object> QueryAsync(
            int index, int size,
            ISpecification<ExaminationInfo> spec = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);
    }
}
