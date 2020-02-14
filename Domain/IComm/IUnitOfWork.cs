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
        void BeginTrans();

        /// <summary>
        /// 提交事务
        /// </summary>
        void CommitTrans();

        /// <summary>
        /// 回滚事务
        /// </summary>
        void RollBackTrans();
    }
}
