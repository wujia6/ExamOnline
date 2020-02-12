using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Application.DTO.Models;
using Domain.Entities.QuestionAgg;
using Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace Application.IServices
{
    /// <summary>
    /// 试题应用服务接口
    /// </summary>
    public interface IQuestionService
    {
        Task<bool> SaveAsync(QuestionDto model);

        Task<bool> EditAsync(QuestionDto model);

        Task<bool> RemoveAsync(Expression<Func<QuestionInfo, bool>> express);

        Task<QuestionDto> SingleAsync(
            Expression<Func<QuestionInfo, bool>> express,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);

        Task<List<QuestionDto>> QueryAsync(
            Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);

        Task<PageResult<QuestionDto>> QueryAsync(
            int index, int size,
            Expression<Func<QuestionInfo, bool>> express = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);
    }
}
