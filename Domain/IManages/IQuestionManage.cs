using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.QuestionAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域服务试题接口
    /// </summary>
    public interface IQuestionManage
    {
        bool SaveAs(QuestionInfo entity);

        bool EditTo(QuestionInfo entity);
        
        bool RemoveAt(ISpecification<QuestionInfo> spec);
        
        Task<QuestionInfo> SingleAsync(
            ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);

        Task<IEnumerable<QuestionInfo>> QueryAsync(
            ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);

        Task<object> QueryAsync(
            int index, int size,
            ISpecification<QuestionInfo> spec = null,
            Func<IQueryable<QuestionInfo>, IIncludableQueryable<QuestionInfo, object>> include = null);
    }
}
