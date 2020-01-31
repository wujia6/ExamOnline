using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.ExamAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    /// <summary>
    /// 考试应用服务接口
    /// </summary>
    public interface IExaminationService
    {
        Task<bool> SaveAsync(ExaminationDto model);

        Task<bool> EditAsync(ExaminationDto model);

        Task<bool> RemoveAsync(Expression<Func<ExaminationInfo, bool>> express);

        Task<ExaminationDto> SingleAsync(
            Expression<Func<ExaminationInfo, bool>> express,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);

        Task<List<ExaminationDto>> QueryAsync(
            Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);

        Task<PageResult<ExaminationDto>> QueryAsync(
            int index, int size,
            Expression<Func<ExaminationInfo, bool>> express = null,
            Func<IQueryable<ExaminationInfo>, IIncludableQueryable<ExaminationInfo, object>> include = null);
    }
}
