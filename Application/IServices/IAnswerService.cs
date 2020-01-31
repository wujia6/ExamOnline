using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.AnwserAgg;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    /// <summary>
    /// 答题卷应用服务接口
    /// </summary>
    public interface IAnswerService
    {
        Task<bool> SaveAsync(AnswerDto model);

        Task<bool> EditAsync(AnswerDto model);

        Task<bool> RemoveAsync(Expression<Func<AnswerInfo, bool>> express);

        Task<AnswerDto> SingleAsync(
            Expression<Func<AnswerInfo, bool>> express,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);

        Task<List<AnswerDto>> QueryAsync(
            Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);

        Task<PageResult<AnswerDto>> QueryAsync(
            int index, int size,
            Expression<Func<AnswerInfo, bool>> express = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);
    }
}
