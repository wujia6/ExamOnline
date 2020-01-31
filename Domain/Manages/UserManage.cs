using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Domain.Entities.UserAgg;
using Domain.IComm;
using Domain.IManages;

namespace Domain.Manages
{
    /// <summary>
    /// 领域用户服务实现类
    /// </summary>
    public class UserManage : IUserManage
    {
        private readonly IEfCoreRepository<UserInfo> efCore;

        public UserManage(IEfCoreRepository<UserInfo> ef)
        {
            this.efCore = ef;
        }

        public bool SaveAs(dynamic entity)
        {
            return efCore.SaveAs(entity);
        }

        public bool EditTo(UserInfo entity)
        {
            return efCore.EditTo(entity);
        }

        public bool RemoveAt(ISpecification<UserInfo> spec)
        {
            var entity = efCore.EntitySet.SingleOrDefault(spec.Expression);
            return entity == null ? false : efCore.RemoveAt(entity);
        }

        public async Task<dynamic> SingleAsync(
            ISpecification<UserInfo> spec, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            return await efCore.EntitySet.FirstOrDefaultAsync(spec.Expression);
        }

        public async Task<IEnumerable<dynamic>> QueryAsync(
            ISpecification<UserInfo> spec = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = await efCore.EntitySet.WhereAsync(spec.Expression);
            return efCore.EntitySet;
        }

        public async Task<object> QueryAsync(
            int index, int size, 
            ISpecification<UserInfo> spec = null, 
            Func<IQueryable<UserInfo>, IIncludableQueryable<UserInfo, object>> include = null)
        {
            if (include != null)
                efCore.EntitySet = include(efCore.EntitySet);
            if (spec != null)
                efCore.EntitySet = efCore.EntitySet.Where(spec.Expression);
            return new
            {
                Total = efCore.EntitySet.Count(),
                Rows = await efCore.EntitySet.Skip((index - 1) * size).Take(size).ToListAsync()
            };
        }
    }
}
