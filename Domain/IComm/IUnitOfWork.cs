using System;
using System.Threading.Tasks;

namespace Domain.IComm
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交更改
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        /// <summary>
        /// 提交更改异步
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// 开始事务
        /// </summary>
        void BeginTransaction();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTransaction();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollBackTransaction();
    }
}
