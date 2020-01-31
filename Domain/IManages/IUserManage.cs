using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Microsoft.EntityFrameworkCore.Query;

namespace Domain.IManages
{
    /// <summary>
    /// 领域用户服务接口
    /// </summary>
    public interface IUserManage
    {
        bool SaveAs(dynamic entity);

        bool EditTo(UserInfo entity);
        
        bool RemoveAt(ISpecification<UserInfo> spec);
        
        Task<dynamic> SingleAsync(
            ISpecification<UserInfo> spec, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
        
        Task<IEnumerable<dynamic>> QueryAsync(
            ISpecification<UserInfo> spec = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
        
        Task<object> QueryAsync(
            int index, int size,
            ISpecification<UserInfo> spec = null,
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null);
    }
}
