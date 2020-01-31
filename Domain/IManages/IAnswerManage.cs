using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.AnwserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 答卷领域服务接口
    /// </summary>
    public interface IAnswerManage
    {
        bool SaveAs(AnswerInfo entity);

        bool EditTo(AnswerInfo entity);
        
        bool RemoveAt(ISpecification<AnswerInfo> spec);
        
        Task<AnswerInfo> SingleAsync(
            ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);

        Task<IEnumerable<AnswerInfo>> QueryAsync(
            ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);

        Task<object> QueryAsync(
            int index, int size,
            ISpecification<AnswerInfo> spec = null,
            Func<IQueryable<AnswerInfo>, IIncludableQueryable<AnswerInfo, object>> include = null);
    }
}
